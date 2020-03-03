using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using StartupBudget.DAL;
using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Developer;

namespace StartupBudget.Web
{
    public static class AutofacConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // builder.RegisterType<DeveloperMockRepository>().As<IDeveloperRepository>();
            builder.RegisterType<StartupBudgetContext>().AsSelf();
            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}