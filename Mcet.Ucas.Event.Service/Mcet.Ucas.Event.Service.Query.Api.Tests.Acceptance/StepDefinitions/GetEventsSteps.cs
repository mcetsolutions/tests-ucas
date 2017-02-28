using FluentAssertions;
using Flurl;
using Flurl.Http;
using Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.Contexts;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public sealed class GetEventsSteps
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings[AppSettingsKeys.BaseUrlEventsQueryApi];

        private readonly ApiContext _context;

        public GetEventsSteps(ApiContext context)
        {
            _context = context;
        }

        [Given(@"a known set of test data exists")]
        public void GivenAKnownSetOfTestDataExists()
        {
            // In memory data store with known set of test data being used so no need to do anything
        }

        [Then(@"the response includes events '(.*)'")]
        public void ThenTheResponseIncludesEvents(IEnumerable<string> eventTitles)
        {
            var result = _context.GetResult<PagedResultModel<EventSummaryModel>>();
            Assert.That(result.Items.Select(e => e.Title), Is.SupersetOf(eventTitles));
        }

        [When(@"I get event '(.*)'")]
        public void WhenIGetEvent(Guid eventId)
        {
            var resourceUrl = BaseUrl.AppendPathSegments("events", eventId);
            using (var client = new Url(resourceUrl).AllowAnyHttpStatus())
            {
                _context.Response = client.GetAsync().GetAwaiter().GetResult();
            }
        }

        [Then(@"the response includes the event details")]
        public void ThenTheResponseIncludesTheEvent(Table expectedEventDetails)
        {
            var expectedEvent = expectedEventDetails.CreateInstance<EventDetailsModel>();
            var actualEvent = _context.GetResult<EventDetailsModel>();
            actualEvent.ShouldBeEquivalentTo(expectedEvent);
        }
    }
}
