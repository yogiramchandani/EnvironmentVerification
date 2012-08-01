using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class DatabaseVerificationSteps : AbstractSteps<DatabaseVerifier>
    {
        [Given("I have a new DatabaseVerifier")]
        public void GivenADatabaseVerifier()
        {
            Context = new DatabaseVerifier();
        }

        [When("I add the DataBase connection name: (.*), connection: (.*)")]
        public void WhenIAddADatabaseConnection(string name, string connection)
        {
            var actions = new Dictionary<string, string>();
            actions.Add("ConnectionString", connection);
            Context.AddConnectionToVerify(name, actions);
        }
        
        [Then("the first result message on the screen should be (.*)")]
        public void ThenTheFirstResultMessageShouldBe(string result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().First().Message.RemoveEscapeChars());
        }

        [Then("the first result verification on the screen should be (.*)")]
        public void ThenTheFirstResultCanConnectShouldBe(ResultType resultType)
        {
            Assert.AreEqual(resultType, Context.GetVerificationStatus().First().Type);
        }

        [Then("the count of messages should be (.*)")]
        public void ThenTheCountOfMessagesShouldBe(int result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().Count());
        }
    }
}
