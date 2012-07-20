﻿using System.Linq;
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

        [When("I add Json objects for processing (.*)")]
        public void WhenIAddJsonItemsForProcessing(string json)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            parser.ParseResourceItems(json);
        }

        [Then("the Json result should have a count of (.*)")]
        public void ThenTheJsonParseResultCountShouldBe(int expected)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            var actual = parser.GetResourceList();
            Assert.AreEqual(actual.Count, expected);
        }

        [Then("the Json result for type (.*) should have a count of (.*)")]
        public void ThenTheJsonParseResultTypeCountShouldBe(string type, int count)
        {
            var parser = ScenarioContext.Current.Get<JsonResourceItemParser>();
            var actual = parser.GetResourceList();
            Assert.AreEqual(actual.Count(x => x.ItemType == type), count);
        }
    }
}
