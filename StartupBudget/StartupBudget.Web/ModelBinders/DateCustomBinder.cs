using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StartupBudget.Web.ViewModels.Project;

namespace StartupBudget.Web.ModelBinders
{
    public class DateCustomBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string name = request.Form.Get("Name");
            string from = request.Form.Get("From");
            string till = request.Form.Get("till");
            string id = request.Form.Get("id");

            int finalId = 0;

            if (!string.IsNullOrEmpty(id))
            {
                if (!int.TryParse(id, out finalId))
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
            }

            var finalFrom = from.Split('/').Select(s => Convert.ToInt32(s)).ToList();
            var finalTill = till.Split('/').Select(s => Convert.ToInt32(s)).ToList();

            return new DetailedProjectViewModel
            {
                Id = finalId,
                Name = name,
                From = new DateTime(finalFrom[2], finalFrom[1], finalFrom[0]),
                Till = new DateTime(finalTill[2], finalTill[1], finalTill[0]),
            };
        }
    }
}