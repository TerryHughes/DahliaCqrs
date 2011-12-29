namespace Dahlia.Data.SQLite
{
    using System.ComponentModel.Composition;
    using Common;

    [Export(typeof(NonQueryDbCommandDescriptor))]
    public class NonQuerySQLiteCommandDescriptor : NonQueryDbCommandDescriptor
    {
        public string ProviderName
        {
            get { return "System.Data.SQLite"; }
        }

        public NonQueryDbCommand Create(string connectionString)
        {
            return new NonQuerySQLiteCommand(connectionString);
        }
    }
}
