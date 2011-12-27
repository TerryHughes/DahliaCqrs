namespace Dahlia.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Dynamic;
    using System.Linq;
    using System.ObjectExtensions;
    using Dahlia.ViewModels;

    public class SqlServerRetreatRepository : RetreatRepository
    {
        public IEnumerable<dynamic> GetAllAsDynamic()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM [dbo].[Retreats]";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName);

                        while (reader.Read())
                        {
                            yield return new ExpandoObject().AddProperties(names, reader);
                        }
                    }

                    command.Connection.Close();
                }
            }
        }
    }

    public static class ExpandoObjectExtensions
    {
        public static ExpandoObject AddProperties(this ExpandoObject expando, IEnumerable<string> names, IDataReader reader)
        {
            var dictionary = (expando as IDictionary<string, object>);

            foreach (var name in names)
            {
                dictionary.Add(name, reader[name]);
            }

            return expando;
        }
    }
}
