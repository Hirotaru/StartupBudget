﻿using StartupBudget.Domain.Developer;
using StartupBudget.Domain.Developer;
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

        public async Task<IEnumerable<SimpleDeveloperViewModel>> GetDevelopers()
        {
            var model = await repository.GetAllDevelopers();
            var viewModel = model.Select(item => new SimpleDeveloperViewModel
            {
                FullName = item.FirstName + " " + item.LastName,
                Qualification = item.Qualification,
                WeekRate = item.WeekRate,
                Id = item.Id
            });

            return viewModel;
        }

        public async Task<SimpleDeveloperViewModel> GetDeveloperToDelete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            var model = (await repository.GetDeveloperById(id.Value));

            if (model == null)
            {
                throw new Exception();
            }

            var viewModel = new SimpleDeveloperViewModel
            {
                Id = model.Id,
                FullName = model.FirstName + " " + model.LastName,
                Qualification = model.Qualification,
                WeekRate = model.WeekRate
            };

            return viewModel;
        }

        public async Task DeleteDeveloper(int id)
        {
            var model = await repository.GetDeveloperById(id);
            await repository.DeleteDeveloper(model);
        }

        

        public Task CreateDeveloper(DetailedDeveloperViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.FirstName))
            {
                throw new ArgumentNullException(nameof(viewModel.FirstName));
            }

            if (string.IsNullOrWhiteSpace(viewModel.LastName))
            {
                throw new ArgumentNullException(nameof(viewModel.LastName));
            }

            if (viewModel.WeekRate <= 0)
            {
                throw new ArgumentException(nameof(viewModel.WeekRate));
            }

            var dev = new Developer
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Qualification = viewModel.Qualification,
                WeekRate = viewModel.WeekRate
            };



            return repository.SaveDeveloper(dev);
        }

        public async Task<DetailedDeveloperViewModel> GetDetailedDeveloper(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var model = (await repository.GetDeveloperById(id));

            if (model == null)
            {
                return null;
            }

            var viewModel = new DetailedDeveloperViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Qualification = model.Qualification,
                WeekRate = model.WeekRate
            };

            return viewModel;
        }

        public Task UpdateDeveloper(DetailedDeveloperViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (string.IsNullOrWhiteSpace(viewModel.FirstName))
            {
                throw new ArgumentNullException(nameof(viewModel.FirstName));
            }

            if (string.IsNullOrWhiteSpace(viewModel.LastName))
            {
                throw new ArgumentNullException(nameof(viewModel.LastName));
            }

            if (viewModel.WeekRate <= 0)
            {
                throw new ArgumentException(nameof(viewModel.WeekRate));
            }

            var model = new Developer
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                WeekRate = viewModel.WeekRate,
                Qualification = viewModel.Qualification
            };

            return repository.UpdateDeveloper(model);
        }
    }
}