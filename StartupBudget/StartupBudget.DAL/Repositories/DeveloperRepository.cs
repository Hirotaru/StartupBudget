using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using StartupBudget.DAL.EF;
using StartupBudget.Domain.Project;

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
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }

            context.Developers.Remove(dev);

            return context.SaveChangesAsync();
        }

        public Task<List<Developer>> GetAllDevelopers()
        {
            return context.Developers.ToListAsync();
        }

        public Task<List<Developer>> GetAllDevelopersWithProjects()
        {
            return context.Developers.Include(d => d.Projects).ToListAsync();
        }

        public Task<Developer> GetDeveloperById(int id)
        {
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

        public Task UpdateDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }

            context.Developers.AddOrUpdate(dev);

            return context.SaveChangesAsync();
        }
    }
}
