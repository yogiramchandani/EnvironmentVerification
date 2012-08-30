using NUnit.Framework;

namespace Core.UnitTest
{
    [TestFixture]
    public class StringFunctionsTest
    {
        [Test]
        public void RemoveEscapeChars_WhereThereAreNoEscapeChars_ExpectSameString()
        {
            string expected = "This is a string with no escape chars";
            string actual = expected.RemoveEscapeChars();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveEscapeChars_WhereThereAreEscapeChars_ExpectStringToBeSmaller()
        {
            string expected = "This is a string with no escape chars \n\r New line";
            string actual = expected.RemoveEscapeChars();

            Assert.IsTrue(expected.Length > actual.Length);
        }
    }
}
