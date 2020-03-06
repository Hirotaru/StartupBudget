using System.Data.Entity;
using StartupBudget.Domain.Developer;
using StartupBudget.Domain.Project;

namespace StartupBudget.DAL.EF
{
    public class StartupBudgetContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }

        public StartupBudgetContext() : base("StartupBudget")
        {
            Database.SetInitializer(new StartupBudgetInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasKey(d => d.Id);
            modelBuilder.Entity<Developer>().Property(d => d.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Developer>().Property(d => d.LastName).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<Project>().Property(p => p.Name).HasMaxLength(255);
            modelBuilder.Entity<Project>().Property(p => p.From).HasColumnType("date");
            modelBuilder.Entity<Project>().Property(p => p.Till).HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }
}
