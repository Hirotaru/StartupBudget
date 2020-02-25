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
        DeveloperWorkService service = DeveloperWorkService.Current;

        // GET: Developers
        
        public async Task<ActionResult> Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Developer, IndexDeveloperViewModel>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName)));

            var mapper = config.CreateMapper();

            var devs = await service.GetDevelopers();

            var indexDevs = mapper.Map<IEnumerable<Developer>, IEnumerable<IndexDeveloperViewModel>>(devs);

            return View(indexDevs);
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
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateDeveloperViewModel, Developer>());

                var mapper = config.CreateMapper();

                var dev = mapper.Map<CreateDeveloperViewModel, Developer>(developer);

                await service.SaveDeveloper(dev);

                return RedirectToAction("Index");
            }

            return View(developer);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
