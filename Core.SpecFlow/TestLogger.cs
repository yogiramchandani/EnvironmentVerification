using System;
using Ninject.Extensions.Logging;

namespace Core.SpecFlow
{
    public class TestLogger : ILog
    {
        public void Debug(string message){}
        public void Debug(string format, params object[] args){}
        public void Debug(Exception exception, string format, params object[] args){}
        public void Info(string message){}
        public void Info(string format, params object[] args){}
        public void Info(Exception exception, string format, params object[] args){}
        public void Trace(string message){}
        public void Trace(string format, params object[] args){}
        public void Trace(Exception exception, string format, params object[] args){}
        public void Warn(string message){}
        public void Warn(string format, params object[] args){}
        public void Warn(Exception exception, string format, params object[] args){}

        void ILog.Error(string message)
        {
            Error(message);
        }

        void ILogger.Error(string message)
        {
            Error(message);
        }

        public void Error(string format, params object[] args){}
        public void Error(Exception exception, string format, params object[] args){}
        public void Fatal(string message){}
        public void Fatal(string format, params object[] args){}
        public void Fatal(Exception exception, string format, params object[] args){}
        public Type Type { get; private set; }
        public bool IsDebugEnabled { get; private set; }
        public bool IsInfoEnabled { get; private set; }
        public bool IsTraceEnabled { get; private set; }
        public bool IsWarnEnabled { get; private set; }
        public bool IsErrorEnabled { get; private set; }
        public bool IsFatalEnabled { get; private set; }
    }
}