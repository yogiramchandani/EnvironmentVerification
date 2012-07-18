using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class ServiceVerificationSteps
    {
        private ServiceVerifier _verifier;

        [Given("I have a new ServiceVerifier")]
        public void GivenAServiceVerifier()
        {
            _verifier = new ServiceVerifier();
        }

        [When("I add a service connection name: (.*), connection: (.*)")]
        public void WhenIAddAServiceConnection(string name, string connection)
        {
            _verifier.AddConnectionToVerify(name, connection);
        }

        [Then("the result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().Message, result);
        }

        [Then("the result status should be (.*)")]
        public void ThenTheResultStatusShouldBe(bool result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().CanConnect, result);
        }

        [Then("the result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().Count, result);
        }
    }
}
