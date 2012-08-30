using System;
using NLog;
using Ninject.Extensions.Logging;

namespace Core
{
    public class Log : Logger, ILog
    {
        public new void Error(string message)
        {
            base.Error(message);
        }

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

    public interface ILog : ILogger
    {
        new void Error(string message);
    }
}
