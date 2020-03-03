using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.DAL.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly StartupBudgetContext context;
        public DeveloperRepository(StartupBudgetContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task DeleteDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Developer>> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public Task<Developer> GetDeveloperById(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }
    }
}
