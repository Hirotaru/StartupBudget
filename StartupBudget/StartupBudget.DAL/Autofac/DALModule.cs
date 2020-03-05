using Autofac;
using StartupBudget.DAL.EF;
using StartupBudget.DAL.Repositories;
using StartupBudget.Domain.Developer;
using StartupBudget.Domain.Project;

namespace StartupBudget.DAL.Autofac
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartupBudgetContext>().AsSelf().SingleInstance();
            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
        }
    }
}
