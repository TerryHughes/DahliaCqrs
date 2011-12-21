namespace Dahlia.Data.SQLite
{
    using System.ComponentModel.Composition;
    using Common;

    [Export(typeof(ReaderDbCommandDescriptor))]
    public class ReaderSQLiteCommandDescriptor : ReaderDbCommandDescriptor
    {
        public string ProviderName
        {
            get { return "System.Data.SQLite"; }
        }

        public ReaderDbCommand Create(string connectionString)
        {
            return new ReaderSQLiteCommand(connectionString);
        }
    }
}
