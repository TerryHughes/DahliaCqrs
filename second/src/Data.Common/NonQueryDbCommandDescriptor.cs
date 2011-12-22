namespace Dahlia.Data.Common
{
    public interface NonQueryDbCommandDescriptor
    {
        string ProviderName { get; }
        NonQueryDbCommand Create(string connectionString);
    }
}
