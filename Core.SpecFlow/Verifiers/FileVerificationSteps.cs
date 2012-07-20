using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class FileVerificationSteps : AbstractSteps<FileVerifier>
    {
        [Given("I have a new FileVerifier")]
        public void GivenAFileVerifier()
        {
            Context = new FileVerifier();
        }

        [When("I add a File path, identifier: (.*), path: (.*)")]
        public void WhenIAddAFileConnection(string name, string connection)
        {
            Context.AddConnectionToVerify(name, connection);
        }

        [Then("the File verification result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Message, result);
        }

        [Then("the File verification status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {

            Assert.AreEqual(Context.GetVerificationStatus().First().Type, resultType);
        }

        [Then("the File verification count should be (.*)")]
        public void ThenTheFileVerificationResultCountShouldBe(int result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().Count, result);
        }
    }
}
