using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Medialink.Api.Filters
{
    public class DivideByZeroExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DivideByZeroException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = context.Exception.InnerException?.Message
                };
            }
        }
    }
}