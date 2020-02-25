using StartupBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartupBudget.Web.ViewModels
{
    public class CreateDeveloperViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WeekRate { get; set; }
        public DeveloperQualification Qualification { get; set; }
    }
}