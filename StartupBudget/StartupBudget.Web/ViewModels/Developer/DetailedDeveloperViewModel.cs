using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StartupBudget.Domain.Developer;

namespace StartupBudget.Web.ViewModels.Developer
{
    public class DetailedDeveloperViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Week Rate")]
        public decimal WeekRate { get; set; }

        public DeveloperQualification Qualification { get; set; }

        public List<DetailedDeveloperViewModel> Projects { get; set; }
    }
}