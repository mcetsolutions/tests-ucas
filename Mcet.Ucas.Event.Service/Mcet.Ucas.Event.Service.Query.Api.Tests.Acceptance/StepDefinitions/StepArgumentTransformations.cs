using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Mcet.Ucas.Event.Service.Query.Api.Tests.Acceptance.StepDefinitions
{
    [Binding]
    public class StepArgumentTransformations
    {
        [StepArgumentTransformation]
        public IEnumerable<string> TransformToEnumerableOfString(string commaSeparatedList)
        {
            return commaSeparatedList.Split(',').Select(i => i.Trim());
        }
    }
}
