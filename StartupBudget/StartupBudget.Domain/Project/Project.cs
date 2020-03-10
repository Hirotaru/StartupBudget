using System;
using System.Collections.Generic;

namespace StartupBudget.Domain.Project
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime Till { get; set; }

        public List<Developer.Developer> Developers { get; set; }

        public Project()
        {
            Developers = new List<Developer.Developer>();
        }
    }
}
