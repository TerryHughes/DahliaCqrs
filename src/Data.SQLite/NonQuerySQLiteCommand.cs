namespace Dahlia.Data.SQLite
{
    using System.Data;
    using System.Data.SQLite;
    using Common;

    public class NonQuerySQLiteCommand : NonQueryDbCommand
    {
        readonly SQLiteConnection connection;
        readonly SQLiteCommand command;

        public NonQuerySQLiteCommand(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            command = new SQLiteCommand(connection);
// check source for SqliteCommand ctor ... (transactions?)
        }

        protected override IDbCommand Command
        {
            get { return command; }
        }

        protected override void AddParameterWithValue(string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value);
        }

        protected override void DisposeManagedResources()
        {
            lock (SyncRoot)
                PerformDisposeManagedResources();
        }

        void PerformDisposeManagedResources()
        {
            DisposeCommand();
            DisposeConnection();
        }

        void DisposeCommand()
        {
            if (command == null)
                return;
System.Console.WriteLine("disposing command");
            command.Dispose();
        }

        void DisposeConnection()
        {
            if (connection == null)
                return;
System.Console.WriteLine("disposing connection");
            connection.Dispose();
System.Console.WriteLine("sleeping for 5 seconds");
System.Threading.Thread.Sleep(5000);
        }
    }
}
