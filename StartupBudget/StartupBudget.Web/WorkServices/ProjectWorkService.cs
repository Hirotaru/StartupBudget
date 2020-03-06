using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using StartupBudget.Domain.Project;
using StartupBudget.Web.ViewModels.Project;

namespace StartupBudget.Web.WorkServices
{
    public class ProjectWorkService
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository repository;

        public ProjectWorkService(IProjectRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<SimpleProjectViewModel>> GetAllProjects()
        {
            var model = await repository.GetAllProjects();
            return mapper.Map<List<SimpleProjectViewModel>>(model);
        }

        public Task CreateProject(DetailedProjectViewModel viewModel)
        {
            Project model = ProcessCheckOnDetailedViewModel(viewModel);

            return repository.SaveProject(model);
        }

        public Task UpdateProject(DetailedProjectViewModel viewModel)
        {
            Project model = ProcessCheckOnDetailedViewModel(viewModel);

            return repository.UpdateProject(model);
        }

        public async Task DeleteProject(SimpleProjectViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var model = await repository.GetProjectById(viewModel.Id);

            if (model == null)
            {
                throw new Exception("Project not found");
            }

            await repository.DeleteProject(model);
        }

        public async Task<SimpleProjectViewModel> GetSimpleProjectById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var model = await repository.GetProjectById(id);

            if (model == null)
            {
                return null;
            }

            return mapper.Map<SimpleProjectViewModel>(model);
        }

        public async Task<DetailedProjectViewModel> GetDetailedProjectById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var model = await repository.GetProjectById(id);

            if (model == null)
            {
                return null;
            }

            return mapper.Map<DetailedProjectViewModel>(model);
        }

        private Project ProcessCheckOnDetailedViewModel(DetailedProjectViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (string.IsNullOrWhiteSpace(viewModel.Name))
            {
                throw new ArgumentNullException(nameof(viewModel.Name));
            }

            if (viewModel.From == null)
            {
                throw new ArgumentNullException(nameof(viewModel.From));
            }

            if (viewModel.To == null)
            {
                throw new ArgumentNullException(nameof(viewModel.To));
            }

            if (viewModel.From >= viewModel.To)
            {
                throw new ArgumentException(nameof(viewModel.From) + " cannot be later than " + nameof(viewModel.To));
            }

            return mapper.Map<Project>(viewModel);
        }
    }
}