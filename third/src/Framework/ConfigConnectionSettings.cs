namespace Dahlia.Framework
{
    using System.Configuration;

    public class ConfigConnectionSettings : ConnectionSettings
    {
        readonly ConnectionStringSettings connectionSettings;

        public ConfigConnectionSettings()
        {
            connectionSettings = ConfigurationManager.ConnectionStrings[0];
        }

        public string ConnectionString
        {
            get { return connectionSettings.ConnectionString; }
        }

        public string ProviderName
        {
            get { return connectionSettings.ProviderName; }
        }
    }
}
