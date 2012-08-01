using System;
using System.Collections.Generic;
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
            var actions = new Dictionary<string, string>();
            actions.Add("FilePath", connection);
            Context.AddConnectionToVerify(name, actions);
        }

        [Then("the File verification result message should be (.*)")]
        public void ThenTheResultMessageShouldBe(string result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().First().Message.RemoveEscapeChars());
        }

        [Then("the File verification status should be (.*)")]
        public void ThenTheResultStatusShouldBe(ResultType resultType)
        {

            Assert.AreEqual(resultType, Context.GetVerificationStatus().First().Type);
        }

        [Then("the File verification count should be (.*)")]
        public void ThenTheFileVerificationResultCountShouldBe(int result)
        {
            Assert.AreEqual(result, Context.GetVerificationStatus().Count);
        }
    }
}
