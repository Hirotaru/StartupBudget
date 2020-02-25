using StartupBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupBudget.Domain.Abstractions
{
    public interface IDeveloperRepository
    {
        Task SaveDeveloper(Developer dev);

        Task<IEnumerable<Developer>> GetAllDevelopers();
    }
}
