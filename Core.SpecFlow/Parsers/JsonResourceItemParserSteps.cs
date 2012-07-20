using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class JsonResourceItemParserSteps
    {
        [Given("I have a new JsonResourceItemProcessor")]
        public void GivenIHaveANewJsonResourceItemProcessor()
        {
            var parser = new JsonResourceItemParser();
            ScenarioContext.Current.Set(parser);
        }

        [When(@"I add string for Json processing ""(.*)""")]
        public void WhenIAddJsonItemsForProcessing(string json)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            VerificationResult result = parser.ParseResourceItems(json);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"the Json result type should be (.*)")]
        public void ThenTheJsonResultTypeShouldBe(ResultType expected)
        {
            var result = ScenarioContext.Current.Get<VerificationResult>();
            Assert.AreEqual(expected, result.Type);
        }

        [Then("the Json result should have a count of (.*)")]
        public void ThenTheJsonParseResultCountShouldBe(int expected)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            var actual = parser.ResourceList;
            Assert.AreEqual(expected, actual.Count);
        }

        [Then("the Json result for type (.*) should have a count of (.*)")]
        public void ThenTheJsonParseResultTypeCountShouldBe(string type, int count)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            var actual = parser.ResourceList;
            Assert.AreEqual(count, actual.Count(x => x.ItemType == type));
        }
    }
}
