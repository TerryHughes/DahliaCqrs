namespace Dahlia.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using ViewModels;

    public class SqlServerRetreatRepository : RetreatRepository
    {
        public IEnumerable<RetreatViewModel> GetAll()
        {
            var connectionString = @"Data Source={Server};Initial Catalog={Database};Integrated Security=SSPI;";

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT [Id], [Date], [Description] FROM [dbo].[Retreates]";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new RetreatViewModel
                            {
                                Id = reader["Id"].As<Guid>(),
                                Date = reader["Date"].As<DateTime>(),
                                Description = reader["Description"].As<string>()
                            };
                        }
                    }

                    command.Connection.Close();
                }
            }
        }
    }
}
