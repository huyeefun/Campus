using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus.Filter
{
    public class ModelValidationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var controller = context.Controller as Controller;
            if (!controller.ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("提醒：");
                foreach (var item in controller.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }
                var result = new ObjectResult(sb.ToString());
                result.StatusCode = 400;
                context.Result = result;
            }
        }
    }
}
