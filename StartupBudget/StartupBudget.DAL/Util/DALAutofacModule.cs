using Autofac;
using StartupBudget.DAL.EF;
using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Developer;

namespace StartupBudget.DAL.Util
{
    public class DALAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartupBudgetContext>().AsSelf().SingleInstance();
            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
        }
    }
}
