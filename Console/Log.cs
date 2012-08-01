using System;
using Ninject.Extensions.Logging;
using NLog;

namespace ConsoleClient
{
    public class Log : Logger, ILogger
    {
        public void Debug(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Type Type { get; private set; }
    }
}
