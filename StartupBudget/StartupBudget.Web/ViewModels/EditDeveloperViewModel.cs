using StartupBudget.Domain.Developer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartupBudget.Web.ViewModels
{
    public class EditDeveloperViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal WeekRate { get; set; }
        public DeveloperQualification Qualification { get; set; }
    }
}