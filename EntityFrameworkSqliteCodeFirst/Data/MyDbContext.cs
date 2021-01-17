using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSqliteCodeFirst.Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);

            modelBuilder.Entity<Tables.Order>()
                .HasRequired<Tables.Person>(o => o.Person)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PersonId);
        }

        public DbSet<Tables.Person> Persons { get; set; }
        public DbSet<Tables.Role> Roles { get; set; }
        public DbSet<Tables.Order> Orders { get; set; }
    }
}
