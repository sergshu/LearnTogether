using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSqlite.DAL
{
    class SqliteHelper
    {
        internal static List<User> GetUsers()
        {
            try
            {
                using(var connection = new SQLiteConnection(@"Data Source=db.sqlite;Version=3;"))
                {
                    connection.Open();

                    using(var cmd = new SQLiteCommand(@"SELECT id,
       user_name,
       name,
       date_created
  FROM users;", connection))
                    {
                        using(var rdr = cmd.ExecuteReader())
                        {
                            List<User> users = new List<User>();

                            while(rdr.Read())
                            {
                                users.Add(new User {
                                    Id = rdr.GetInt32(0),
                                    UserName = rdr.GetString(1),
                                    Name = rdr.GetString(2),
                                    Date = rdr.GetDateTime(3)
                                });
                            }

                            return users;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return null;
        }
    }
}
