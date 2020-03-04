using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using StartupBudget.DAL.Autofac;

namespace StartupBudget.Web
{
    public static class AutofacConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new DALModule());

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}