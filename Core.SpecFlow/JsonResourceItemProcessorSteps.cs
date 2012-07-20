using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class JsonResourceItemProcessorSteps
    {
        JsonResourceItemParser _parser;

        [Given("I have a new JsonResourceItemProcessor")]
        public void GivenIHaveANewJsonResourceItemProcessor()
        {
            _parser = new JsonResourceItemParser();
        }

        [When("I add Json objects for processing (.*)")]
        public void WhenIAddJsonItemsForProcessing(string json)
        {
            _parser.ParseResourceItems(json);
        }

        [Then("the Json result should have a count of (.*)")]
        public void ThenTheJsonParseResultCountShouldBe(int expected)
        {
            var actual = _parser.GetResourceList();
            Assert.AreEqual(actual.Count, expected);
        }

        [Then("the Json result for type (.*) should have a count of (.*)")]
        public void ThenTheJsonParseResultTypeCountShouldBe(string type, int count)
        {
            var actual = _parser.GetResourceList();
            Assert.AreEqual(actual.Count(x => x.ItemType == type), count);
        }
    }
}
