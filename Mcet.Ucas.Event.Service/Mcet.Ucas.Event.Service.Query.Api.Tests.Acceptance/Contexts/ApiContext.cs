using Newtonsoft.Json;
using System.Net.Http;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.Contexts
{
    public class ApiContext
    {
        public HttpResponseMessage Response { get; set; }

        public T GetResult<T>()
        {
            return JsonConvert.DeserializeObject<T>(Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
    }
}
