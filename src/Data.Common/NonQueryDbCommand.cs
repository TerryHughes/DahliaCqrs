namespace Dahlia.Data.Common
{
    using System.Collections.Generic;
    using System.Data;
    using Framework;

    public abstract class NonQueryDbCommand : ManagedDisposable
    {
        protected readonly object SyncRoot = new object();

        protected abstract IDbCommand Command { get; }

        public void ExecuteWith(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            ThrowExceptionIfDisposed();

            lock (SyncRoot)
                PerformExecuteWith(statement, pairs);
        }

        protected abstract void AddParameterWithValue(string parameterName, object value);

        void PerformExecuteWith(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            Command.CommandText = statement;
            AddParameters(pairs);
            ExecuteNonQuery();
        }

        void AddParameters(IEnumerable<KeyValuePair<string, object>> pairs)
        {
            foreach (var pair in pairs)
                AddParameterWithValue(pair.Key, pair.Value);
        }

        void ExecuteNonQuery()
        {
//System.Console.WriteLine("sleeping for 5 seconds");
//System.Threading.Thread.Sleep(5000);
System.Console.WriteLine("opening connection " + this.GetType());
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
System.Console.WriteLine("closing connection " + this.GetType());
        }
    }
}
