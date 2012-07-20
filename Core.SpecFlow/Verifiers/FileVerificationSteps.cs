using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class FileVerificationSteps
    {
        private FileVerifier _verifier;

        [Given("I have a new FileVerifier")]
        public void GivenAFileVerifier()
        {
            _verifier = new FileVerifier();
        }

        [When("I add a File path, identifier: (.*), path: (.*)")]
        public void WhenIAddAFileConnection(string name, string connection)
        {
            _verifier.AddConnectionToVerify(name, connection);
        }

        [Then("the File verification result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().Message, result);
        }

        [Then("the File verification status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {

            Assert.AreEqual(_verifier.GetVerificationStatus().First().Type, resultType);
        }

        [Then("the File verification count should be (.*)")]
        public void ThenTheFileVerificationResultCountShouldBe(int result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().Count, result);
        }
    }
}
