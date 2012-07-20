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
            Context.AddConnectionToVerify(name, connection);
        }
        
        [Then("the first result message on the screen should be (.*)")]
        public void ThenTheFirstResultMessageShouldBe(string result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Message, result);
        }

        [Then("the first result verification on the screen should be (.*)")]
        public void ThenTheFirstResultCanConnectShouldBe(ResultType resultType)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Type, resultType);
        }

        [Then("the count of messages should be (.*)")]
        public void ThenTheCountOfMessagesShouldBe(int result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().Count(), result);
        }
    }
}
