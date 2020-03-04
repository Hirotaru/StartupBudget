using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using StartupBudget.Web.Automapper;

namespace StartupBudget.Web.Autofac
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DeveloperProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
        }
    }
}