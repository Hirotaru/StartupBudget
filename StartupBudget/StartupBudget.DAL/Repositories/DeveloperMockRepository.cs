using StartupBudget.Domain.Abstractions;
using StartupBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupBudget.DAL.Repositories
{
    public class DeveloperMockRepository : IDeveloperRepository
    {
        private int nextId = 3;
        private static readonly List<Developer> DataSource;

        static DeveloperMockRepository()
        {
            DataSource = new List<Developer>()
            {
                new Developer {Id = 1, FirstName = "Василий", LastName = "Пупкин", Qualification = DeveloperQualification.Senior, WeekRate = 2000},
                new Developer {Id = 2, FirstName = "Иван", LastName = "Иванов", Qualification = DeveloperQualification.Middle, WeekRate = 1500}
            };
        }

        public DeveloperMockRepository()
        {

        }

        public async Task SaveDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException();
            }

            dev.Id = nextId++;

            DataSource.Add(dev);

            await Task.Delay(500); //Database query imitation
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers()
        {
            await Task.Delay(500); //Database query imitation
            return DataSource;
        }
    }
}
