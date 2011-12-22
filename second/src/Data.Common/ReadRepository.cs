namespace Dahlia.Data.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Framework;

    public class ReadRepository
    {
        readonly ConnectionSettings settings;
        readonly ReaderDbCommandFactory factory;

        public ReadRepository(ConnectionSettings settings)
        {
            this.settings = settings;
            factory = new ReaderDbCommandFactory();
        }

        public IEnumerable<dynamic> All(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            using (var command = factory.Create(settings.ProviderName, settings.ConnectionString))
                return command.ExecuteWith(statement, pairs);
        }

        public dynamic One(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            return All(statement, pairs).Single();
        }
    }
}
