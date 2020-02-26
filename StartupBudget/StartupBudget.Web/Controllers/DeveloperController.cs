using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Developer;
using StartupBudget.Web.ViewModels;
using StartupBudget.Web.WorkServices;

namespace StartupBudget.Web.Controllers
{
    [HandleError]
    public class DeveloperController : Controller
    {
        DeveloperWorkService service = new DeveloperWorkService(new DeveloperMockRepository());

        // GET: Developers
        public async Task<ActionResult> Developers()
        {
            var response = await service.GetDevelopers();

            return View(response);
        }

        // GET: Developers/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDeveloperViewModel developer)
        {
            await service.CreateDeveloper(developer);

            return RedirectToAction("Developers");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            DeleteDeveloperViewModel viewModel = await service.GetDeveloperToDelete(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteDeveloper(id);
            return RedirectToAction("Developers");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            var viewModel = await service.GetDetailsDeveloper(id);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var viewModel = await service.GetDeveloperToEdit(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditDeveloperViewModel viewModel)
        {
            await service.UpdateDeveloper(viewModel);
            return RedirectToAction("Developers");
        }
    }
}
