using Mcet.Ucas.Event.Service.Query.Api.App_Start;
using System.Web.Http;

namespace Mcet.Ucas.Event.Service.Query.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Configure();
            IocConfig.Configure(GlobalConfiguration.Configuration);
        }
    }
}
