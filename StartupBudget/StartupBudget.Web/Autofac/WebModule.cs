using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using StartupBudget.DAL.Autofac;
using StartupBudget.Web.Automapper;
using StartupBudget.Web.Extensions;

namespace StartupBudget.Web.Autofac
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new DALModule());

            builder.UseAutoMapper();
        }
    }
}