namespace Dahlia.Data.SqlClient
{
    using System.Data;
    using System.Data.SqlClient;
    using Common;

    public class NonQuerySqlCommand : NonQueryDbCommand
    {
        readonly SqlConnection connection;
        readonly SqlCommand command;

        public NonQuerySqlCommand(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
// check docs for SqlCommand ctor ... (transactions?)
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

            command.Dispose();
        }

        void DisposeConnection()
        {
            if (connection == null)
                return;

            connection.Dispose();
        }
    }
}
