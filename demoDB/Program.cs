using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace demoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                [Mytable](
                                [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [NAME] NVARCHAR(2048) NOT NULL,
                                [GENDER] NVARCHAR(2048) NOT NULL)";
                                
            System.Data.SQLite.SQLiteConnection.CreateFile("simple.db3");
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=database.simple.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = createQuery;

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO mytable(NAME,GENDER) values('alex','male')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText= "INSERT INTO mytable(NAME,GENDER) values('diane','female')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select * from Mytable";
                    using(System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["NAME"] + ":" + reader["GENDER"]);
                        }
                        conn.Close();
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
