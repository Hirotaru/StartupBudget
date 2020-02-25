using StartupBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupBudget.Domain.Abstractions
{
    public interface IDeveloperRepository : IDisposable
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();

        Task<Developer> GetDeveloperByIdAsync(int id);

        Task CreateDeveloperAsync(Developer dev);

        Task UpdateDeveloperAsync(Developer dev);

        Task DeleteDeveloperAsync(Developer dev);

        Task SaveDeveloperAsync();
    }
}
