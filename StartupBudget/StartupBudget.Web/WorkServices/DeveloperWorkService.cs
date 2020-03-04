using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StartupBudget.Domain.Developer;
using StartupBudget.Web.ViewModels;

namespace StartupBudget.Web.WorkServices
{
    public class DeveloperWorkService
    {
        private readonly IDeveloperRepository repository;
        private readonly IMapper mapper;

        public DeveloperWorkService(IDeveloperRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SimpleDeveloperViewModel>> GetDevelopers()
        {
            var model = await repository.GetAllDevelopers();
            var viewModel = mapper.Map<List<SimpleDeveloperViewModel>>(model);

            return viewModel;
        }

        public Task CreateDeveloper(DetailedDeveloperViewModel viewModel)
        {
            Developer model = ProcessDetailedViewModel(viewModel);

            return repository.SaveDeveloper(model);
        }

        public Task UpdateDeveloper(DetailedDeveloperViewModel viewModel)
        {
            Developer model = ProcessDetailedViewModel(viewModel);

            return repository.UpdateDeveloper(model);
        }

        public async Task DeleteDeveloper(SimpleDeveloperViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var model = await repository.GetDeveloperById(viewModel.Id);

            if (model == null)
            {
                throw new Exception("Developer not found");
            }

            await repository.DeleteDeveloper(model);
        }

        public async Task<DetailedDeveloperViewModel> GetDetailedDeveloperById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var model = await repository.GetDeveloperById(id);

            if (model == null)
            {
                return null;
            }

            var viewModel = mapper.Map<DetailedDeveloperViewModel>(model);

            return viewModel;
        }

        public async Task<SimpleDeveloperViewModel> GetSimpleDeveloperById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var model = await repository.GetDeveloperById(id);

            if (model == null)
            {
                return null;
            }

            var viewModel = mapper.Map<SimpleDeveloperViewModel>(model);

            return viewModel;
        }

        private Developer ProcessDetailedViewModel(DetailedDeveloperViewModel viewModel)
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

            var model = mapper.Map<Developer>(viewModel);

            return model;
        }
    }
}