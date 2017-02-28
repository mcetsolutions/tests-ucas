using Flurl;
using Flurl.Http;
using Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.Contexts;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using NUnit.Framework;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public sealed class GetSortedEventsSteps
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings[AppSettingsKeys.BaseUrlEventsQueryApi];

        private readonly ApiContext _context;
        private PagedResultModel<EventSummaryModel> _result;
        private string _orderBy;
        private bool _ascending;

        public GetSortedEventsSteps(ApiContext context)
        {
            _context = context;
        }

        private PagedResultModel<EventSummaryModel> Result
        {
            get
            {
                return _result ?? (_result = _context.GetResult<PagedResultModel<EventSummaryModel>>());
            }
        }

        [When(@"I get sorted events")]
        public void WhenIGetSortedEvents()
        {
            var resourceUrl = BaseUrl.AppendPathSegments("events").SetQueryParams(new { orderBy = _orderBy, ascending = _ascending });
            if (string.IsNullOrEmpty(_orderBy))
            {
                resourceUrl.RemoveQueryParam("orderBy");
            }

            using (var client = new Url(resourceUrl).AllowAnyHttpStatus())
            {
                _context.Response = client.GetAsync().GetAwaiter().GetResult();
            }
        }

        [Then(@"the results are ordered by descending StartDate")]
        public void ThenTheResultsAreOrderedByDescendingStartDate()
        {
            Assert.That(Result.Items.First().Title, Is.EqualTo("Widget Corp"));
            Assert.That(Result.Items.Last().Title, Is.EqualTo("C 4 Network Inc 'Shows that pop!'"));
        }

        [Given(@"a sort order of ascending Title")]
        public void GivenASortOrderOfAscendingTitle()
        {
            _orderBy = "Title";
            _ascending = true;
        }

        [Then(@"the results are ordered by ascending Title")]
        public void ThenTheResultsAreOrderedByAscendingTitle()
        {
            Assert.That(Result.Items.First().Title, Is.EqualTo("20 20 Printing Inc"));
            Assert.That(Result.Items.Last().Title, Is.EqualTo("Ankh-Sto Associates"));
        }
    }
}
