namespace Dahlia.Data.Common
{
    using System.Collections.Generic;
    using Framework;

    public class WriteRepository
    {
        readonly ConnectionSettings settings;
        readonly NonQueryDbCommandFactory factory;

        public WriteRepository(ConnectionSettings settings)
        {
            this.settings = settings;
            factory = new NonQueryDbCommandFactory();
        }

        public void Do(string statement, IEnumerable<KeyValuePair<string, object>> pairs)
        {
            using (var command = factory.Create(settings.ProviderName, settings.ConnectionString))
                command.ExecuteWith(statement, pairs);
        }
    }
}
