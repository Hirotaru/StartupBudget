using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StartupBudget.Web.ModelBinders;
using StartupBudget.Web.ViewModels.Project;

namespace StartupBudget.Web
{
#pragma warning disable SA1649
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfigurator.ConfigureDependencyInjection();

            System.Web.Mvc.ModelBinders.Binders.Add(typeof(DetailedProjectViewModel), new DateCustomBinder());
        }
    }
}
