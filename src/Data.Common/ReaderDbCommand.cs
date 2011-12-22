namespace Dahlia.Data.Common
{
    using System.Collections.Generic;
    using System.Data;
    using Framework;

    public abstract class ReaderDbCommand : ManagedDisposable
    {
        protected readonly object SyncRoot = new object();

        protected abstract IDbCommand Command { get; }

        public IEnumerable<dynamic> ExecuteWith(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            ThrowExceptionIfDisposed();

            lock (SyncRoot)
                return PerformExecuteWith(statement, pairs);
        }

        protected abstract void AddParameterWithValue(string parameterName, object value);

        IEnumerable<dynamic> PerformExecuteWith(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            Command.CommandText = statement;
            AddParameters(pairs);

            return Execute();
        }

        void AddParameters(IEnumerable<KeyValuePair<string, object>> pairs)
        {
            foreach (var pair in pairs)
                AddParameterWithValue(pair.Key, pair.Value);
        }

        IEnumerable<dynamic> Execute()
        {
            Command.Connection.Open();
            var result = Reader();
            Command.Connection.Close();

            return result;
        }

        IEnumerable<dynamic> Reader()
        {
            using (var creator = new DynamicCreator(Command))
                return creator.Read();
        }
    }
}
