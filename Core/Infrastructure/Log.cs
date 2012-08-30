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
            DebugException(format, exception);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            InfoException(format, exception);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            TraceException(format, exception);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            WarnException(format, exception);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            ErrorException(format, exception);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            FatalException(format, exception);
        }

        public Type Type { get; private set; }
    }

    public interface ILog : ILogger
    {
        new void Error(string message);
    }
}
