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
    public sealed class GetPaginatedEventsSteps
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings[AppSettingsKeys.BaseUrlEventsQueryApi];

        private readonly ApiContext _context;
        private PagedResultModel<EventSummaryModel> _result;
        private int? _pageSize;

        public GetPaginatedEventsSteps(ApiContext context)
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

        [When(@"I get page (.*) of events")]
        public void WhenIGetPageOfEvents(int pageNumber)
        {
            var resourceUrl = BaseUrl.AppendPathSegments("events").SetQueryParams(new { pageNumber = pageNumber, pageSize = _pageSize });
            if (!_pageSize.HasValue)
            {
                resourceUrl.RemoveQueryParam("pageSize");
            }

            using (var client = new Url(resourceUrl).AllowAnyHttpStatus())
            {
                _context.Response = client.GetAsync().GetAwaiter().GetResult();
            }
        }

        [Then(@"the response page number is (.*)")]
        public void ThenTheResponseDefaultsToPage(int pageNumber)
        {
            Assert.That(Result.PageNumber, Is.EqualTo(pageNumber));
        }

        [Then(@"the first page result is event with title '(.*)'")]
        public void ThenTheFirstPageResultIsEventWithTitle(string eventTitle)
        {
            Assert.That(Result.Items.First().Title, Is.EqualTo(eventTitle));
        }

        [Then(@"the last page result is event with title '(.*)'")]
        public void ThenTheLastPageResultIsEventWithTitleShowsThatPop(string eventTitle)
        {
            Assert.That(Result.Items.Last().Title, Is.EqualTo(eventTitle));
        }

        [Given(@"a page size of (.*)")]
        public void GivenAPageSizeOf(int pageSize)
        {
            _pageSize = pageSize;
        }

        [Then(@"the total number of pages is (.*)")]
        public void ThenTheTotalNumberOfPagesIs(int totalPages)
        {
            Assert.That(Result.TotalPages, Is.EqualTo(totalPages));
        }

        [Then(@"the number of page items is (.*)")]
        public void ThenTheNumberOfPageItemsIs(int numberOfPageItems)
        {
            Assert.That(Result.Items.Count, Is.EqualTo(numberOfPageItems));
        }

        [Then(@"the response page size is (.*)")]
        public void ThenTheResponsePageSizeIs(int pageSize)
        {
            Assert.That(Result.PageSize, Is.EqualTo(pageSize));
        }

        [Then(@"the total number of events is (.*)")]
        public void ThenTheTotalNumberOfEventsIs(int totalEvents)
        {
            Assert.That(Result.TotalResults, Is.EqualTo(totalEvents));
        }
    }
}
