using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupBudget.Domain.Developer
{
    public interface IDeveloperRepository
    {
        Task SaveDeveloper(Developer dev);

        Task<List<Developer>> GetAllDevelopers();

        Task DeleteDeveloper(Developer dev);

        Task<Developer> GetDeveloperById(int id);

        Task UpdateDeveloper(Developer dev);
    }
}
