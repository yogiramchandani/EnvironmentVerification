using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class DirectoryVerificationSteps : AbstractSteps<DirectoryVerifier>
    {
        [Given("I have a new DirectoryVerifier")]
        public void GivenADirectoryVerifier()
        {
            Context = new DirectoryVerifier();
        }

        [When("I add a directory path, identifier: (.*), path: (.*)")]
        public void WhenIAddADirectoryConnection(string name, string connection)
        {
            Context.AddConnectionToVerify(name, connection);
        }

        [Then("the directory verification result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Message, result);
        }

        [Then("the directory verification status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {
            Assert.AreEqual(Context.GetVerificationStatus().First().Type, resultType);
        }

        [Then("the directory verification count should be (.*)")]
        public void ThenTheDirectoryVerificationResultCountShouldBe(int result)
        {
            Assert.AreEqual(Context.GetVerificationStatus().Count, result);
        }
    }
}
