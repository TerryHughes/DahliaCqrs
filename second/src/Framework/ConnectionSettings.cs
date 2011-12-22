namespace Dahlia.Framework
{
    public interface ConnectionSettings
    {
        string ConnectionString { get; }
        string ProviderName {get; }
    }
}
