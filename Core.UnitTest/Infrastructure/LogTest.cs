using NUnit.Framework;
using Ninject.Extensions.Logging;

namespace Core.UnitTest
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void Log_InvokeDefaultConstructor_ExpectLogIsATypeOfILog()
        {
            Log logger = new Log();
            Assert.IsInstanceOf<ILog>(logger);
        }

        [Test]
        public void Log_InvokeDefaultConstructor_ExpectLogIsATypeOfILogger()
        {
            Log logger = new Log();
            Assert.IsInstanceOf<ILogger>(logger);
        }
    }
}
