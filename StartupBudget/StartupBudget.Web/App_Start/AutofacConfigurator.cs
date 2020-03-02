using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using StartupBudget.Domain.Developer;
using StartupBudget.Mocks.Repositories;

namespace StartupBudget.Web
{
    public static class AutofacConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DeveloperMockRepository>().As<IDeveloperRepository>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}