using StartupBudget.Domain.Developer;
using StartupBudget.Domain.Project;
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

            var proj = new List<Project>
            {
                new Project {Name = "Test Project 1", From = new System.DateTime(2020, 2, 18), To = new System.DateTime(2020, 5, 18)}
            };

            foreach (var item in proj)
            {
                context.Projects.Add(item);
            }

            context.SaveChanges();
        }
    }
}
