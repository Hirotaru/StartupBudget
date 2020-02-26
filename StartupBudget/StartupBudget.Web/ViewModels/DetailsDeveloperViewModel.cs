using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartupBudget.Web.ViewModels
{
    public class DetailsDeveloperViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal WeekRate { get; set; }
        public DeveloperQualification Qualification { get; set; }
    }
}