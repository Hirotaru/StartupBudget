using StartupBudget.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StartupBudget.Web.ViewModels
{
    public class CreateDeveloperViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal WeekRate { get; set; }
        public DeveloperQualification Qualification { get; set; }
    }
}