using StartupBudget.Domain.Developer;
using StartupBudget.Domain.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupBudget.Mocks.Repositories
{
    public class DeveloperMockRepository : IDeveloperRepository
    {
        private static int nextId = 1;
        private static readonly List<Developer> DataSource;

        static DeveloperMockRepository()
        {
            DataSource = new List<Developer>()
            {
                new Developer {Id = nextId++, FirstName = "Василий", LastName = "Пупкин", Qualification = DeveloperQualification.Senior, WeekRate = 2000},
                new Developer {Id = nextId++, FirstName = "Иван", LastName = "Иванов", Qualification = DeveloperQualification.Middle, WeekRate = 1500},
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

        public async Task<List<Developer>> GetAllDevelopers()
        {
            await Task.Delay(500); //Database query imitation
            return DataSource;
        }

        public async Task DeleteDeveloper(Developer dev)
        {
            await Task.Delay(500);
            DataSource.Remove(dev);
        }

        public async Task<Developer> GetDeveloperById(int id)
        {
            var dev = DataSource.Where(d => d.Id == id).FirstOrDefault();
            await Task.Delay(500);
            return dev;
        }

        public async Task UpdateDeveloper(Developer dev)
        {
            int index = DataSource.FindIndex(d => d.Id == dev.Id);

            if (index < 0)
            {
                throw new Exception();
            }

            await Task.Delay(500);

            DataSource[index] = dev;
        }

        public Task<List<Developer>> GetDevelopersInProject(Project proj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Developer>> GetDevelopersNotInProject(Project proj)
        {
            throw new NotImplementedException();
        }
    }
}
