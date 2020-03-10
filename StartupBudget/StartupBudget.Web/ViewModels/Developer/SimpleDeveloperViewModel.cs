using System.ComponentModel.DataAnnotations;
using StartupBudget.Domain.Developer;

namespace StartupBudget.Web.ViewModels.Developer
{
    public class SimpleDeveloperViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Week Rate")]
        public decimal WeekRate { get; set; }

        public DeveloperQualification Qualification { get; set; }
    }
}