using System.Collections.Generic;

namespace StartupBudget.Domain.Developer
{
    public class Developer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal WeekRate { get; set; }

        public DeveloperQualification Qualification { get; set; }

        public List<Project.Project> Projects { get; set; }

        public Developer()
        {
            Projects = new List<Project.Project>();
        }
    }
}
