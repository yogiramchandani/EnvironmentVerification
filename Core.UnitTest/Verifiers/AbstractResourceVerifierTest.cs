using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Core.UnitTest
{
    [TestFixture]
    public class AbstractResourceVerifierTest
    {
        [Test]
        public void TestResourceVerifier_WhereAValidDictionaryIsPassed_ExpectASuccess()
        {
            var mut = new TestResourceVerifier("Key", new Dictionary<string, string>{{"Key1", "Value1"}});
            List<VerificationResult> actual = mut.GetVerificationStatus();
            Assert.AreEqual(ResultType.Success, actual.First().Type);
        }

        [Test]
        public void TestResourceVerifier_WhereAnEmptyDictionaryIsPassed_ExpectAFailure()
        {
            var mut = new TestResourceVerifier("Key", new Dictionary<string, string>());
            List<VerificationResult> actual = mut.GetVerificationStatus();
            Assert.AreEqual(ResultType.Failure, actual.First().Type);
        }

        [Test]
        public void TestResourceVerifier_WhereANullDictionaryIsPassed_ExpectAFailure()
        {
            var mut = new TestResourceVerifier("Key", null);
            List<VerificationResult> actual = mut.GetVerificationStatus();
            Assert.AreEqual(ResultType.Failure, actual.First().Type);
        }

        sealed class TestResourceVerifier : AbstractResourceVerifier
        {
            public TestResourceVerifier(string key, IDictionary<string, string> dictionary)
            {
                AddConnectionToVerify(key, dictionary);
            }

            protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple)
            {
                return new VerificationResult{Message = "Success", Type = ResultType.Success};
            }
        }

    }
}
