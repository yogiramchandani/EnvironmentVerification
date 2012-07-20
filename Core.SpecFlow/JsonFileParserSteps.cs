using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class JsonFileParserSteps
    {
        private JsonFileParser _parser;

        [Given("I have a new Json file parser with a file path (.*)")]
        public void GivenIHaveANewJsonFileParser(string filePath)
        {
            _parser = new JsonFileParser(filePath);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

            ScenarioContext.Current.Pending();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            ScenarioContext.Current.Pending();
        }
    }

    public class JsonFileParser : IFileParser
    {
        public JsonFileParser(string filePath)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFileParser
    {
    }
}
