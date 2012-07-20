using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class FileReaderSteps : AbstractSteps<FileReader>
    {
        [When(@"I create a new file reader with path ""(.*)""")]
        public void WhenICreateANewFileReaderWithPath(string file)
        {
            Context = new FileReader(file);
        }

        [When(@"I call validate file")]
        public void WhenICallValidateFile()
        {
            ValidationResult result = Context.Validate();
            ScenarioContext.Current.Set(result);
        }

        [Then(@"the validation result type should be ""(.*)""")]
        public void ThenTheValidationResultShouldBeSuccess(ResultType type)
        {
            ValidationResult result = ScenarioContext.Current.Get<ValidationResult>();
            Assert.AreEqual(result.Type, type);
        }

        [Then(@"the validation result content should be ""(.*)""")]
        public void ThenTheValidationResultContentShouldBe(string expected)
        {
            ValidationResult result = ScenarioContext.Current.Get<ValidationResult>();
            Assert.AreEqual(result.Message.RemoveEscapeChars().ToLowerInvariant(), expected.RemoveEscapeChars().ToLowerInvariant());
        }
    }
}
