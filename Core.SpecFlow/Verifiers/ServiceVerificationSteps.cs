using System.Collections.Generic;
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
            var actions = new Dictionary<string, string>();
            actions.Add("ServiceName", connection);
            Context.AddConnectionToVerify(name, actions);
        }

        [Then("the result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().First().Message.RemoveEscapeChars());
        }

        [Then("the result status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {
            Assert.AreEqual(resultType, Context.GetVerificationStatus().First().Type);
        }

        [Then("the result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().Count);
        }
    }
}
