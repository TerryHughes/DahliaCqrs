namespace Dahlia.Framework
{
    using System.Configuration;

    public class ConfigConnectionSettings : ConnectionSettings
    {
        readonly ConnectionStringSettings connectionSettings;

        public ConfigConnectionSettings(string name)
        {
            connectionSettings = ConfigurationManager.ConnectionStrings[name];
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
