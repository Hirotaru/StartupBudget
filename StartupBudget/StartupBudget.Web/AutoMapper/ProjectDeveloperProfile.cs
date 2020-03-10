using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StartupBudget.Domain.Project;
using StartupBudget.Web.ViewModels.ProjectDeveloper;

namespace StartupBudget.Web.Automapper
{
    public class ProjectDeveloperProfile : Profile
    {
        public ProjectDeveloperProfile()
        {
            CreateMap<Project, DetailsProjectDeveloperViewModel>();
        }
    }
}