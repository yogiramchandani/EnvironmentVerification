using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class DatabaseVerificationSteps
    {
        private DatabaseVerifier _verifier;

        [Given("I have a new DatabaseVerifier")]
        public void GivenADatabaseVerifier()
        {
            _verifier = new DatabaseVerifier();
        }

        [When("I add a DataBase connection that exists")]
        public void WhenIAddADatabaseConnectionThatIsPresent()
        {
            _verifier.AddConnectionToVerify("Nirvana", @"Data Source=.\CDR;Initial Catalog=nirvana_small;Integrated Security=SSPI");
        }

        [When("I add a DataBase connection that does not exist")]
        public void WhenIAddADatabaseConnectionThatIsNotPresent()
        {
            _verifier.AddConnectionToVerify("NirvanaNotExists", @"Data Source=.\CDR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI");
        }

        [Then("the first result message on the screen should be (.*)")]
        public void ThenTheFirstResultMessageShouldBe(string result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().Message, result);
        }

        [Then("the first result verification on the screen should be (.*)")]
        public void ThenTheFirstResultCanConnectShouldBe(bool result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().CanConnect, result);
        }

        [Then("the count of messages should be (.*)")]
        public void ThenTheCountOfMessagesShouldBe(int result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().Count(), result);
        }
    }
}
