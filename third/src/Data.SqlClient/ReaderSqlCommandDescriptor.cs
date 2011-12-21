namespace Dahlia.Data.SqlClient
{
    using System.ComponentModel.Composition;
    using Common;

    [Export(typeof(ReaderDbCommandDescriptor))]
    public class ReaderSqlCommandDescriptor : ReaderDbCommandDescriptor
    {
        public string ProviderName
        {
            get { return "System.Data.SqlClient"; }
        }

        public ReaderDbCommand Create(string connectionString)
        {
            return new ReaderSqlCommand(connectionString);
        }
    }
}
