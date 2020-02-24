using StartupBudget.Abstractions;
using StartupBudget.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.DAL.Repositories
{
    public class MockRepository : IRepository<Developer>
    {
        private readonly List<Developer> DataSource;
        static MockRepository current;
        public static MockRepository Current
        {
            get
            {
                if (current == null)
                {
                    current = new MockRepository();
                }
                return current;
            }
        }


        private MockRepository()
        {
            DataSource = new List<Developer>()
            {
                new Developer {Id = 1, FullName = "Пупкин Василий Петрович", Qualification = "Senior", WeekRate = 2000},
                new Developer {Id = 2, FullName = "Иваной Иван Иванвич", Qualification = "Middle", WeekRate = 1500}
            };
        }
        public void Create(Developer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            DataSource.Add(item);
        }

        public void Delete(Developer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            DataSource.Remove(item);
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");
        }

        public IEnumerable<Developer> GetAll()
        {
            return DataSource;
        }

        public Developer GetById(int? id)
        {
            if (id.HasValue)
            {
                return GetById(id.Value);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public Developer GetById(int id)
        {
            return DataSource.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            Console.WriteLine("Saving data...");
        }

        public void Update(Developer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            int index = DataSource.FindIndex(t => t.Id == item.Id);

            if (index > 0)
            {
                DataSource[index] = item;
            }
        }
    }
}
