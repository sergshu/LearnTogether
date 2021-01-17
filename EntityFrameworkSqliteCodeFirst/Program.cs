using EntityFrameworkSqliteCodeFirst.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSqliteCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    bool changed = false;

                    if (cont.Roles.Count() == 0)
                    {
                        cont.Roles.Add(new Data.Tables.Role { Name = "User" });
                        cont.Roles.Add(new Data.Tables.Role { Name = "Admin" });

                        changed = true;
                    }

                    //var person = new Data.Tables.Person { Name = "Test" + DateTime.Now.Millisecond };
                    //cont.Persons.Add(person);
                    //cont.SaveChanges();

                    foreach (var p in cont.Persons.Include("Orders"))
                    {
                        if (!p.Age.HasValue)
                        {
                            p.Age = DateTime.Now.Second;
                            changed = true;
                        }

                        if (!p.RoleId.HasValue)
                        {
                            p.RoleId = 1;
                            changed = true;
                        }

                        if (p.Orders.Count == 0)
                        {
                            p.Orders.Add(new Data.Tables.Order { Name = "Order 1", Date = DateTime.Now });
                            changed = true;
                        }
                    }

                    if (changed)
                    {
                        cont.SaveChanges();
                    }

                    foreach (var p in cont.Persons.Include("Orders").Include("PersonRole"))
                    {
                        Console.WriteLine(p.ToPersonsString());
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine();
            Console.WriteLine("Wait");
            Console.ReadKey();
        }
    }
}
