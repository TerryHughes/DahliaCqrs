namespace Dahlia.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;

    public class ReaderDbCommandFactory
    {
        readonly IDictionary<string, Func<string, ReaderDbCommand>> readers;

        public ReaderDbCommandFactory()
        {
            readers = new Dictionary<string, Func<string, ReaderDbCommand>>();

            Initialize();
        }

        public ReaderDbCommand Create(string providerName, string connectionString)
        {
            if (readers.ContainsKey(providerName))
                return readers[providerName](connectionString);

            throw new NotSupportedException("There is no read support for " + providerName);
        }

        void Initialize()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            var descriptors = container.GetExportedValues<ReaderDbCommandDescriptor>();

            foreach (var descriptor in descriptors)
                readers.Add(descriptor.ProviderName, descriptor.Create);
        }
    }
}
