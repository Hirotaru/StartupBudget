using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StartupBudget.Domain.Project;
using StartupBudget.Web.ViewModels.Project;

namespace StartupBudget.Web.Automapper
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, SimpleProjectViewModel>();

            CreateMap<Project, DetailedProjectViewModel>().ReverseMap();
        }
    }
}