using System;
using System.Collections.Generic;
using System.Data.Entity;
using StartupBudget.Domain.Developer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.DAL
{
    public class StartupBudgetContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public StartupBudgetContext() : base("StartupBudget")
        {
            Database.SetInitializer(new StartupBudgetInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasKey(d => d.Id);
            modelBuilder.Entity<Developer>().Property(d => d.FirstName).IsRequired();
            modelBuilder.Entity<Developer>().Property(d => d.LastName).IsRequired();
            modelBuilder.Entity<Developer>().Property(d => d.WeekRate).HasColumnType("money");

            base.OnModelCreating(modelBuilder);
        }
    }
}
