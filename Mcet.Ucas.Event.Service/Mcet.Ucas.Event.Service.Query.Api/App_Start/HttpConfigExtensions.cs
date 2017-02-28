using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Mcet.Ucas.Event.Service.Query.Api.App_Start
{
    internal static class HttpConfigExtensions
    {
        public static void RegisterJsonWebApiFormatter(this HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.Indented;
            jsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}