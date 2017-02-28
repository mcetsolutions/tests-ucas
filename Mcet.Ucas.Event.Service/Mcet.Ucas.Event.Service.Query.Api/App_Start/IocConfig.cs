using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Web.Http;

namespace Mcet.Ucas.Event.Service.Query.Api.App_Start
{
    public static class IocConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            RegisterModules(builder, assembly);
            builder.RegisterApiControllers(assembly);

            var resolver = new AutofacWebApiDependencyResolver(builder.Build());
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void RegisterModules(ContainerBuilder builder, Assembly sourceAssembly)
        {
            builder.RegisterAssemblyModules(sourceAssembly);

            var configuration = new ConfigurationBuilder().AddJsonFile("autofac.json");
            builder.RegisterModule(new ConfigurationModule(configuration.Build()));
        }
    }
}