using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Abstractions;
using StartupBudget.Domain.Entities;

namespace StartupBudget.Web.Controllers
{
    public class DevelopersController : Controller
    {
        IDeveloperRepository db = DeveloperMockRepository.Current;

        // GET: Developers
        public async Task<ActionResult> Index()
        {
            return View(await db.GetAllDevelopersAsync());
        }

        // GET: Developers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Developer developer = await db.GetDeveloperByIdAsync(id.Value);

            if (developer == null)
            {
                return HttpNotFound();
            }

            return View(developer);
        }

        // GET: Developers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                await db.CreateDeveloperAsync(developer);
                await db.SaveDeveloperAsync();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

        // GET: Developers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Developer developer = await db.GetDeveloperByIdAsync(id.Value);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Developer developer)
        {
            if (ModelState.IsValid)
            {
                await db.UpdateDeveloperAsync(developer);
                await db.SaveDeveloperAsync();
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        // GET: Developers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Developer developer = await db.GetDeveloperByIdAsync(id.Value);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Developer developer = await db.GetDeveloperByIdAsync(id);
            await db.DeleteDeveloperAsync(developer);
            await db.SaveDeveloperAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
