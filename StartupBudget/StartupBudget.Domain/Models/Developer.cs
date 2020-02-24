using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupBudget.Domain.Models
{
    public class Developer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int WeekRate { get; set; }

        public string Qualification { get; set; }
    }
}
