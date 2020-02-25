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
        private readonly List<Developer> DataSource;
        static DeveloperMockRepository current;
        public static DeveloperMockRepository Current
        {
            get
            {
                if (current == null)
                {
                    current = new DeveloperMockRepository();
                }
                return current;
            }
        }


        private DeveloperMockRepository()
        {
            DataSource = new List<Developer>()
            {
                new Developer {Id = 1, FullName = "Пупкин Василий Петрович", Qualification = "Senior", WeekRate = 2000},
                new Developer {Id = 2, FullName = "Иваной Иван Иванвич", Qualification = "Middle", WeekRate = 1500}
            };
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            await Task.Delay(500); //Database query imitation
            return DataSource;
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            await Task.Delay(500); //Database query imitation
            return DataSource.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task CreateDeveloperAsync(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException();
            }

            dev.Id = nextId++;

            DataSource.Add(dev);

            await Task.Delay(500); //Database query imitation
        }

        public async Task UpdateDeveloperAsync(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException();
            }

            int index = DataSource.FindIndex(t => t.Id == dev.Id);

            if (index > 0)
            {
                DataSource[index] = dev;
            }
            await Task.Delay(500); //Database query imitation
        }

        public async Task DeleteDeveloperAsync(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException();
            }

            DataSource.Remove(dev);
            await Task.Delay(500); //Database query imitation
        }

        public async Task SaveDeveloperAsync()
        {
            Console.WriteLine("Saving data...");
            await Task.Delay(500); //Database query imitation
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");
        }
    }
}
