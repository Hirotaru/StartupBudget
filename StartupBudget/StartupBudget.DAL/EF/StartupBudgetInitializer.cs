using StartupBudget.Domain.Developer;
using System.Collections.Generic;
using System.Data.Entity;

namespace StartupBudget.DAL.EF
{
    public class StartupBudgetInitializer : DropCreateDatabaseIfModelChanges<StartupBudgetContext>
    {
        protected override void Seed(StartupBudgetContext context)
        { 
            var devs = new List<Developer>()
            {
                new Developer { FirstName = "Василий", LastName = "Пупкин", Qualification = DeveloperQualification.Senior, WeekRate = 2000 },
                new Developer { FirstName = "Иван", LastName = "Иванов", Qualification = DeveloperQualification.Middle, WeekRate = 1500 },
            };

            foreach (var item in devs)
            {
                context.Developers.Add(item);
            }

            context.SaveChanges();
        }
    }
}
