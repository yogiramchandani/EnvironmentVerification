using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Core.UnitTest
{
    [TestFixture]
    public class UnknownVerifierTest : UnknownVerifier
    {
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
            Assert.AreEqual("Failure: Could not find a valid verifier for the following elements: \r\nKey: Item1, Value: Action1\r\nKey: Item2, Value: Action2\r\n", actual);
        }
    }
}
