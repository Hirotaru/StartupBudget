using System.Data.Entity;
using StartupBudget.Domain.Developer;

namespace StartupBudget.DAL.EF
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
            modelBuilder.Entity<Developer>().Property(d => d.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Developer>().Property(d => d.LastName).IsRequired().HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}
