namespace Dahlia.Spikes.SQLite
{
    using System;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;

    static class Program
    {
        static void Main()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var file = Path.Combine(path, "spike.dat");

#if READ
            var conn = new SQLiteConnection(@"Data Source=" + file + ";Version=3;Read Only=True;");
#else
            var conn = new SQLiteConnection(@"Data Source=" + file + ";Version=3;");
#endif
            conn.Open();
            var cmd = new SQLiteCommand(conn);
#if CREATE
            cmd.CommandText = "CREATE TABLE [Foo]([Bar] VARCHAR(20) NOT NULL)";
            cmd.ExecuteNonQuery();
#endif
#if UPDATE
            cmd.CommandText = "INSERT INTO [Foo] ([Bar]) VALUES ('" + DateTime.Now.ToLongTimeString() + "')";
            cmd.ExecuteNonQuery();
#endif
#if READ
            var line = String.Empty;
            while ((line = Console.ReadLine()) == String.Empty)
            {
                cmd.CommandText = "SELECT * FROM [Foo]";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine(reader["Bar"]);
                }
            }
#endif
#if DROP
            cmd.CommandText = "DROP TABLE [Foo]";
            cmd.ExecuteNonQuery();
#endif
            conn.Close();
        }
    }
}
