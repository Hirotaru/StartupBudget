using StartupBudget.DAL.EF;
using StartupBudget.Domain.Project;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly StartupBudgetContext context;
        public ProjectRepository(StartupBudgetContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task DeleteProject(Project proj)
        {
            if (proj == null)
            {
                throw new ArgumentNullException(nameof(proj));
            }

            context.Projects.Remove(proj);

            return context.SaveChangesAsync();
        }

        public Task<List<Project>> GetAllProjects()
        {
            return context.Projects.ToListAsync();
        }

        public Task<Project> GetProjectById(int id)
        {
            return context.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task SaveProject(Project proj)
        {
            if (proj == null)
            {
                throw new ArgumentNullException(nameof(proj));
            }

            context.Projects.Add(proj);

            return context.SaveChangesAsync();
        }

        public Task UpdateProject(Project proj)
        {
            if (proj == null)
            {
                throw new ArgumentNullException(nameof(proj));
            }

            context.Projects.AddOrUpdate(proj);

            return context.SaveChangesAsync();
        }
    }
}
