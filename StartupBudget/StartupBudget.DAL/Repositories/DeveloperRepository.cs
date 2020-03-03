using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StartupBudget.DAL.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly StartupBudgetContext context;
        public DeveloperRepository(StartupBudgetContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance; //Без этого не работает
        }
        public Task DeleteDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }

            context.Developers.Remove(dev);

            return context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopers()
        {
            return await context.Developers.ToListAsync();
        }

        public Task<Developer> GetDeveloperById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            return context.Developers.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public Task SaveDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }

            context.Developers.Add(dev);

            return context.SaveChangesAsync();
        }

        public async Task UpdateDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }

            var devToChange = await context.Developers.Where(d => d.Id == dev.Id).FirstOrDefaultAsync();

            if (devToChange == null)
            {
                throw new Exception();
            }

            context.Entry(devToChange).CurrentValues.SetValues(dev);

            await context.SaveChangesAsync();
        }
    }
}
