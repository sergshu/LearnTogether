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
                using(var cont = new Data.MyDbContext())
                {
                    var person = new Data.Tables.Person { Name = "Test" + DateTime.Now.Millisecond };
                    cont.Persons.Add(person);
                    cont.SaveChanges();

                    bool changed = false;
                    foreach(var p in cont.Persons)
                    {
                        if(!p.Age.HasValue)
                        {
                            p.Age = DateTime.Now.Second;
                            changed = true;
                        }
                    }

                    if(changed)
                    {
                        cont.SaveChanges();
                    }
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
