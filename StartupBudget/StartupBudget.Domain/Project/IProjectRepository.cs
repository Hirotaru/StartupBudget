using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.Domain.Project
{
    public interface IProjectRepository
    {
        Task SaveProject(Project proj);

        Task<List<Project>> GetAllProjects();

        Task DeleteProject(Project proj);

        Task<Project> GetProjectById(int id);

        Task UpdateProject(Project proj);
    }
}
