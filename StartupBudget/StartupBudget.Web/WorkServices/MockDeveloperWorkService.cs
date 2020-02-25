using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Abstractions;
using StartupBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StartupBudget.Web.WorkServices
{
    public class MockDeveloperWorkService
    {
        private readonly IDeveloperRepository repository;

        private static MockDeveloperWorkService current;

        public static MockDeveloperWorkService Current
        {
            get 
            { 
                if (current == null)
                {
                    current = new MockDeveloperWorkService(new DeveloperMockRepository());
                }
                return current;
            }
            set { current = value; }
        }

        public MockDeveloperWorkService(IDeveloperRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            return await repository.GetAllDevelopers();
        }

        public async Task SaveDeveloper(Developer dev)
        {
            await repository.SaveDeveloper(dev);
        }
    }
}