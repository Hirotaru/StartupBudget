using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StartupBudget.Web.ViewModels.Developer;

namespace StartupBudget.Web.ViewModels.ProjectDeveloper
{
    public class DetailsProjectDeveloperViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Till { get; set; }

        public List<DetailedDeveloperViewModel> Developers { get; set; }
    }
}