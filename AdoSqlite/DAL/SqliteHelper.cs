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
                using (var connection = new SQLiteConnection(@"Data Source=db.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(@"SELECT id,
       user_name,
       name,
       date_created
  FROM users;", connection))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            List<User> users = new List<User>();

                            while (rdr.Read())
                            {
                                users.Add(new User
                                {
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

        internal static bool AddUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=db.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand($@"INSERT INTO users (
                      user_name,
                      name,
                      date_created
                  )
                  VALUES (
                      '{user.UserName}',
                      '{user.Name}',
                      '{user.Date:yyyy-MM-dd}');", connection))
                    {
                        var res = cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        internal static bool SaveUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=db.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand($@"UPDATE users  
SET
user_name = '{user.UserName}',
name = '{user.Name}',
date_created = '{user.Date:yyyy-MM-dd}'
WHERE id = {user.Id};", connection))
                    {
                        var res = cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        internal static bool DeleteUser(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=db.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand($@"DELETE FROM users WHERE id = {id};", connection))
                    {
                        var res = cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
    }
}
