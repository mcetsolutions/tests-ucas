using Flurl;
using Flurl.Http;
using Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.Contexts;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public sealed class GetEventsCommonSteps
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings[AppSettingsKeys.BaseUrlEventsQueryApi];

        private readonly ApiContext _context;

        public GetEventsCommonSteps(ApiContext context)
        {
            _context = context;
        }

        [When(@"I get all events")]
        public void WhenIGetAllEvents()
        {
            var resourceUrl = BaseUrl.AppendPathSegments("events");
            using (var client = new Url(resourceUrl).AllowAnyHttpStatus())
            {
                _context.Response = client.GetAsync().GetAwaiter().GetResult();
            }
        }
    }
}
