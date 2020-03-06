using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartupBudget.Web.ViewModels.Project
{
    public class SimpleProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}