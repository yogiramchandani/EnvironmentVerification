using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Core.UnitTest
{
    [TestFixture]
    public class VerificationProcessorTest
    {
        [Test]
        public void VerificationProcessor_WhereResourceIsPassedWithNullItems_ExpectAFailureResult()
        {
            var mut = new VerificationProcessor<string>(null);
            mut.AddResourceItems(new List<IResourceItem<string>>{new ResourceItem()});
            List<VerificationResult> actual = mut.ProcessResources();
            Assert.AreEqual(ResultType.Failure, actual.First().Type);
        }
    }
}
