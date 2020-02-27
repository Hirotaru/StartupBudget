﻿using System;
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
    
    public class DeveloperController : Controller
    {
        private readonly DeveloperWorkService service = new DeveloperWorkService(new DeveloperMockRepository());

        // GET: Developers
        public async Task<ActionResult> Developers()
        {
            var viewModel = await service.GetDevelopers();
            return View(viewModel);
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
        public async Task<ActionResult> Create(DetailedDeveloperViewModel developer)
        {
            await service.CreateDeveloper(developer);
            return RedirectToAction("Developers");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            SimpleDeveloperViewModel viewModel = await service.GetSimpleDeveloperById(id);

            if (viewModel == null)
            {
                ViewBag.Id = id;
                return View("DeveloperNotFound");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SimpleDeveloperViewModel viewModel)
        {
            await service.DeleteDeveloper(viewModel);
            return RedirectToAction("Developers");
        }

        [HttpGet, ActionName("Id")]
        public async Task<ActionResult> Details(int id)
        {
            var viewModel = await service.GetDetailedDeveloperById(id);

            if (viewModel == null)
            {
                ViewBag.Id = id;
                return View("DeveloperNotFound");
            }

            return View("Details", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var viewModel = await service.GetDetailedDeveloperById(id);

            if (viewModel == null)
            {
                ViewBag.Id = id;
                return View("DeveloperNotFound");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DetailedDeveloperViewModel viewModel)
        {
            await service.UpdateDeveloper(viewModel);
            return RedirectToAction("Developers");
        }
    }
}
