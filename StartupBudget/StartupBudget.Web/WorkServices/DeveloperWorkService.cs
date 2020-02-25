using StartupBudget.Domain.Abstractions;
using StartupBudget.Domain.Entities;
using StartupBudget.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace StartupBudget.Web.WorkServices
{
    public class DeveloperWorkService
    {
        private readonly IDeveloperRepository repository;

        public DeveloperWorkService(IDeveloperRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }

            this.repository = repository;
        }

        public async Task<IEnumerable<IndexDeveloperViewModel>> GetDevelopers()
        {
            var devs = await repository.GetAllDevelopers();
            var IndexDevs = devs.Select(item => new IndexDeveloperViewModel
            {
                FullName = item.FirstName + " " + item.LastName,
                Qualification = item.Qualification,
                WeekRate = item.WeekRate,
                Id = item.Id
            });

            return IndexDevs;
        }

        public Task CreateDeveloper(CreateDeveloperViewModel CreatedDev)
        {
            if (CreatedDev.FirstName.Trim(' ').IsEmpty())
            {
                //???
            }

            if (CreatedDev.LastName.Trim(' ').IsEmpty())
            {
                //???
            }

            if (CreatedDev.WeekRate <= 0)
            {
                //???
            }

            var dev = new Developer
            {
                FirstName = CreatedDev.FirstName,
                LastName = CreatedDev.LastName,
                Qualification = CreatedDev.Qualification,
                WeekRate = CreatedDev.WeekRate
            };



            return repository.SaveDeveloper(dev);
        }
    }
}