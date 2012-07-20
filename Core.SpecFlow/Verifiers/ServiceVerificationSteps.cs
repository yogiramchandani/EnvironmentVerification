using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class ServiceVerificationSteps : AbstractSteps<ServiceVerifier>
    {
        [Given("I have a new ServiceVerifier")]
        public void GivenAServiceVerifier()
        {
            Context = new ServiceVerifier();
        }

        [When("I add a service connection name: (.*), connection: (.*)")]
        public void WhenIAddAServiceConnection(string name, string connection)
        {
            Context.AddConnectionToVerify(name, connection);
        }

        [Then("the result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Message, result);
        }

        [Then("the result status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Type, resultType);
        }

        [Then("the result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().Count, result);
        }
    }
}
