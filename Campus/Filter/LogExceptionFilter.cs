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
        //1.可以通过构造函数声明依赖，拿到 ILogger，在 Setup 中配置这个 filter 的时候要注入依赖

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            //2.通过 http 上下文的 RequestServices
            var logger = context.HttpContext.RequestServices.GetService<ILogger<LogExceptionFilter>>();
            logger.LogError("An error has encounted in the action", context.Exception);
        }
    }
}
