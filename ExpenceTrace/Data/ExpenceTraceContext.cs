using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Expence_Treace.Models;

namespace ExpenceTrace.Data
{
    public class ExpenceTraceContext : DbContext
    {
        public ExpenceTraceContext (DbContextOptions<ExpenceTraceContext> options)
            : base(options)
        {
        }

        public DbSet<Expence_Treace.Models.Category> Category { get; set; } = default!;

        public DbSet<Expence_Treace.Models.User> User { get; set; }

        public DbSet<Expence_Treace.Models.ExpenceDetails> ExpenceDetails { get; set; }
    }
}
