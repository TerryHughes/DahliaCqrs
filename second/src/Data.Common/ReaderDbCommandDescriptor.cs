namespace Dahlia.Data.Common
{
    public interface ReaderDbCommandDescriptor
    {
        string ProviderName { get; }
        ReaderDbCommand Create(string connectionString);
    }
}
