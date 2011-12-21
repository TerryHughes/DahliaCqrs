namespace Dahlia.Data.SqlClient
{
    using System.ComponentModel.Composition;
    using Common;

    [Export(typeof(NonQueryDbCommandDescriptor))]
    public class NonQuerySqlCommandDescriptor : NonQueryDbCommandDescriptor
    {
        public string ProviderName
        {
            get { return "System.Data.SqlClient"; }
        }

        public NonQueryDbCommand Create(string connectionString)
        {
            return new NonQuerySqlCommand(connectionString);
        }
    }
}
