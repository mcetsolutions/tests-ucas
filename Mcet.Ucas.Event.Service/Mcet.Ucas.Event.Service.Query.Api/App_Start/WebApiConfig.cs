using Mcet.Ucas.Event.Service.Query.Api.App_Start;
using Mcet.Ucas.Event.Service.Query.Api.Handlers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mcet.Ucas.Event.Service.Query.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.RegisterJsonWebApiFormatter();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MessageHandlers.Add(new PreflightRequestsHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
