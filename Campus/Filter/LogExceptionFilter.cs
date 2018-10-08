using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.Filter
{
    public class LogExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var logger = context.HttpContext.RequestServices.GetService<ILogger<LogExceptionFilter>>();
            logger.LogError("An error has encounted in the action", context.Exception);
        }
    }
}
