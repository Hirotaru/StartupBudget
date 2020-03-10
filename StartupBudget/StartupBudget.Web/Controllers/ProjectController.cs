using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StartupBudget.Domain.Project;
using StartupBudget.Web.ModelBinders;
using StartupBudget.Web.ViewModels.Project;
using StartupBudget.Web.WorkServices;

namespace StartupBudget.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectWorkService service;

        public ProjectController(IProjectRepository repository, IMapper mapper)
        {
            service = new ProjectWorkService(repository, mapper);
        }

        [HttpGet]
        public async Task<ActionResult> Projects()
        {
            return View(await service.GetAllProjects());
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var viewModel = await service.GetSimpleProjectById(id);

            if (viewModel == null)
            {
                return ProjectNotFound(id);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SimpleProjectViewModel viewModel)
        {
            await service.DeleteProject(viewModel);
            return RedirectToAction("Projects");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([ModelBinder(typeof(DateCustomBinder))] DetailedProjectViewModel project)
        {
            await service.CreateProject(project);
            return RedirectToAction("Projects");
        }

        [HttpGet]
        [ActionName("Id")]
        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await service.GetDetailsProjectDeveloperById(id);

            if (viewModel == null)
            {
                return ProjectNotFound(id);
            }

            return View("Details", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var viewModel = await service.GetDetailedProjectById(id);

            if (viewModel == null)
            {
                return ProjectNotFound(id);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([ModelBinder(typeof(DateCustomBinder))] DetailedProjectViewModel viewModel)
        {
            await service.UpdateProject(viewModel);
            return RedirectToAction("Projects");
        }

        private ActionResult ProjectNotFound(int id)
        {
            return View("ProjectNotFound", new ProjectNotFoundViewModel { Id = id });
        }
    }
}