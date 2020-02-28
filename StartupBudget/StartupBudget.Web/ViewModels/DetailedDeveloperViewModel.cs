using System.ComponentModel.DataAnnotations;
using StartupBudget.Domain.Developer;

namespace StartupBudget.Web.ViewModels
{
    public class DetailedDeveloperViewModel
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