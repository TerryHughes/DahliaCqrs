namespace Dahlia.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;

    public class NonQueryDbCommandFactory
    {
        readonly IDictionary<string, Func<string, NonQueryDbCommand>> doers;

        public NonQueryDbCommandFactory()
        {
            doers = new Dictionary<string, Func<string, NonQueryDbCommand>>();

            Initialize();
        }

        public NonQueryDbCommand Create(string providerName, string connectionString)
        {
            if (doers.ContainsKey(providerName))
                return doers[providerName](connectionString);

            throw new NotSupportedException("There is no write support for " + providerName);
        }

        void Initialize()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            var descriptors = container.GetExportedValues<NonQueryDbCommandDescriptor>();

            foreach (var descriptor in descriptors)
                doers.Add(descriptor.ProviderName, descriptor.Create);
        }
    }
}
