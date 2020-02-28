using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StartupBudget.Domain.Developer;

namespace StartupBudget.Web.ViewModels
{
    public class SimpleDeveloperViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal WeekRate { get; set; }

        public DeveloperQualification Qualification { get; set; }
    }
}