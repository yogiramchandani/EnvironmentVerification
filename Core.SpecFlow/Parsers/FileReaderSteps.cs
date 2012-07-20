using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class FileReaderSteps : AbstractSteps<FileParser>
    {
        [When(@"I create a new file reader with path ""(.*)""")]
        public void WhenICreateANewFileReaderWithPath(string file)
        {
            Context = new FileParser(file);
        }

        [When(@"I call validate file")]
        public void WhenICallValidateFile()
        {
            VerificationResult result = Context.Parse();
            ScenarioContext.Current.Set(result);
        }

        [Then(@"the validation result type should be ""(.*)""")]
        public void ThenTheValidationResultShouldBeSuccess(ResultType type)
        {
            VerificationResult result = ScenarioContext.Current.Get<VerificationResult>();
            Assert.AreEqual(result.Type, type);
        }

        [Then(@"the validation result content should be ""(.*)""")]
        public void ThenTheValidationResultContentShouldBe(string expected)
        {
            VerificationResult result = ScenarioContext.Current.Get<VerificationResult>();
            Assert.AreEqual(result.Message, expected);
        }
    }
}
