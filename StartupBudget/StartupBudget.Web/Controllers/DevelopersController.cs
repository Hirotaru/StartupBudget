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
using StartupBudget.Domain.Abstractions;
using StartupBudget.Domain.Entities;
using StartupBudget.Web.ViewModels;
using StartupBudget.Web.WorkServices;

namespace StartupBudget.Web.Controllers
{
    public class DevelopersController : Controller
    {
        DeveloperWorkService service = new DeveloperWorkService(new DeveloperMockRepository());

        // GET: Developers
        public async Task<ActionResult> Index()
        {
            var response = await service.GetDevelopers();

            return View(response);
        }

        // GET: Developers/Create
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

            return RedirectToAction("Index");
        }
    }
}
