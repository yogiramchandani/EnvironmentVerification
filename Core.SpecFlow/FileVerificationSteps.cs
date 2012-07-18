using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public void ThenTheResultStatusShouldBe(bool result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().First().CanConnect, result);
        }

        [Then("the File verification count should be (.*)")]
        public void ThenTheFileVerificationResultCountShouldBe(int result)
        {
            Assert.AreEqual(_verifier.GetVerificationStatus().Count, result);
        }
    }

    public class FileVerifier : ResourceVerifier
    { 
        protected override bool Verify(Tuple<string, string> tuple)
        {
            return File.Exists(tuple.Item2);
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("{0} connecting to {1}, file path: {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
        }
    }
}
