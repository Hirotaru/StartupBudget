using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using StartupBudget.Web.Automapper;

namespace StartupBudget.Web.Extensions
{
    public static class AutofacExtensions
    {
        public static void UseAutoMapper(this ContainerBuilder builder)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DeveloperProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();
        }
    }
}