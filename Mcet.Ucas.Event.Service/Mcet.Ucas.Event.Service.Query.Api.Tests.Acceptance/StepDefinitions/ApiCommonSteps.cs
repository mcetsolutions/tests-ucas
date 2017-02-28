using Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.Contexts;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public sealed class ApiCommonSteps
    {
        private readonly ApiContext _context;

        public ApiCommonSteps(ApiContext context)
        {
            _context = context;
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int statusCode)
        {
            Assert.That(_context.Response.StatusCode, Is.EqualTo((HttpStatusCode)statusCode));
        }
    }
}
