namespace Dahlia.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.ObjectExtensions;

    public interface ProcessCommandRepository
    {
        IEnumerable<Guid> CommandsSince(DateTime date);
    }

    public class SqlServerProcessCommandRepository : ProcessCommandRepository
    {
        public IEnumerable<Guid> CommandsSince(DateTime date)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT [Id] FROM [dbo].[ProcessedCommands] WHERE [Date] > '" + date.ToString() + "'";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader["Id"].As<Guid>();
                        }
                    }

                    command.Connection.Close();
                }
            }
        }
    }
}
