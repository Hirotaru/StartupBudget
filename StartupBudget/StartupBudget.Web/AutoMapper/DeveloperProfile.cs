using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StartupBudget.Domain.Developer;
using StartupBudget.Web.ViewModels;

namespace StartupBudget.Web.Automapper
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            CreateMap<Developer, SimpleDeveloperViewModel>().ForMember(vm => vm.FullName, opt => opt.MapFrom(m => m.FirstName + " " + m.LastName));
            CreateMap<Developer, DetailedDeveloperViewModel>();
            CreateMap<Developer, DeveloperNotFoundViewModel>();
            CreateMap<List<Developer>, List<SimpleDeveloperViewModel>>();
        }
    }
}