using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EndPointService.Controllers.v1
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        string GetExceptionInnerMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetExceptionInnerMessage(ex.InnerException);
        }

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            var exceptionResult = new ExceptionResult(GetExceptionInnerMessage(context.Exception));

            if (context.HttpContext.Request.Headers.ContainsKey("IncludeExceptionDetails"))
                exceptionResult.Exception = context.Exception;

            context.Result = new JsonResult(exceptionResult, settings);
            base.OnException(context);
        }


        public class ExceptionResult
        {
            public ExceptionResult(string message)
            {
                Message = message;
            }

            public string Message { get; set; }

            public Exception Exception { get; set; }
        }
    }
}
