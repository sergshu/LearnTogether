using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDI.Data
{
    public class LtContext : DbContext
    {
        public LtContext(DbContextOptions<LtContext> options) : base(options)
        {

        }

        public DbSet<TestItem> TestItems { get; set; }
    }
}
