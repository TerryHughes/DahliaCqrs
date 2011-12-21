namespace Dahlia.Spikes.MEF
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using Data.Common;

    static class Program
    {
        static void Main()
        {
            var catalog = new DirectoryCatalog(".");
            var container = new CompositionContainer(catalog);
            var descriptors = container.GetExportedValues<ReaderDbCommandDescriptor>();

            foreach (var descriptor in descriptors)
                Console.WriteLine(descriptor.ProviderName);
        }
    }
}
