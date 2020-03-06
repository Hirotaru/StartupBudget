using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StartupBudget.Domain.Project;
using StartupBudget.Web.WorkServices;

namespace StartupBudget.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectWorkService service;

        public ProjectController(IProjectRepository repository, IMapper mapper)
        {
            var a = 5;
        }

        [HttpGet]
        public ActionResult Projects()
        {
            return View();
        }
    }
}