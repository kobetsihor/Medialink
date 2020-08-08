using System.Web.Http;
using Medialink.Api.Filters;

namespace Medialink.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
