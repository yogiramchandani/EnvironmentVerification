using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Core.UnitTest
{
    [TestFixture]
    public class UnknownVerifierTest : UnknownVerifier
    {
        public UnknownVerifierTest() : base("Test"){}
        public UnknownVerifierTest(string verifierName) : base(verifierName) { }

        [Test]
        public void ConstructMessage_Where2ElementsExistInTheDictionary_ExpectTheDictionaryListInMessage()
        {
            string actual = ConstructMessage(
                new Tuple<string, IDictionary<string, string>>("TestMessages", new Dictionary<string, string>
                                                                                   {
                                                                                       {"Item1", "Action1"},
                                                                                       {"Item2", "Action2"}
                                                                                   }),
                new VerificationResult {Type = ResultType.Failure});
            Assert.AreEqual("Failure: Could not find a valid verifier for 'Test' with the following elements: \r\nKey: Item1, Value: Action1\r\nKey: Item2, Value: Action2\r\n", actual);
        }

        [Test]
        public void CallConstructor_ProvideAStringForTheVerifierName_ExpectTheVerifierNamePropertySet()
        {
            string verifierName = "TestVerifier";
            var mut = new UnknownVerifierTest(verifierName);

            Assert.AreEqual(verifierName, mut.VerifierName);
        }
    }
}
