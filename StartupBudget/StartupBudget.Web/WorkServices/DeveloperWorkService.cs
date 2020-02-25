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
    public class DeveloperWorkService
    {
        private readonly IDeveloperRepository repository;

        private static DeveloperWorkService current;

        public static DeveloperWorkService Current
        {
            get 
            { 
                if (current == null)
                {
                    current = new DeveloperWorkService(new DeveloperMockRepository());
                }
                return current;
            }
            set { current = value; }
        }

        public DeveloperWorkService(IDeveloperRepository repository)
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