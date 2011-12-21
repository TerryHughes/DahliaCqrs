namespace Dahlia.Data
{
    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;
    using System.Linq;
    using Framework;

    public class DynamicCreator : ManagedDisposable
    {
        readonly object syncRoot = new object();
        readonly IDataReader reader;
        readonly IEnumerable<string> names;

        public DynamicCreator(IDbCommand command)
        {
            reader = command.ExecuteReader();
            names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName);
        }

        public IEnumerable<dynamic> Read()
        {
            ThrowExceptionIfDisposed();

            lock (syncRoot)
                return PerformRead().ToList();
        }

        protected override void DisposeManagedResources()
        {
            lock (syncRoot)
                DisposeReader();
        }

        void DisposeReader()
        {
            if (reader == null)
                return;

            reader.Dispose();
        }

        IEnumerable<dynamic> PerformRead()
        {
            while (reader.Read())
                yield return ComposeExpando();
        }

        dynamic ComposeExpando()
        {
            var expando = new ExpandoObject();
            var dictionary = expando as IDictionary<string, object>;

            foreach (var name in names)
                dictionary.Add(name, reader[name]);

            return expando;
        }
    }
}
