using System;
using Ninject;

namespace Core
{
    public abstract class AbstractParser<T> : IParser where T:Exception
    {
        [Inject]
        public ILog Logger { get; set; }

        public virtual VerificationResult Parse()
        {
            try
            {
                return Execute();
            }
            catch(T e)
            {
                string message = ConstructExceptionMessage(e);
                Logger.Error(e, message);
                return new VerificationResult { Message = message, Type = ResultType.Failure };
            }
        }

        protected abstract VerificationResult Execute();

        protected abstract string ConstructExceptionMessage(T e);
    }

    public interface IParser
    {
        ILog Logger { get; set; }

        VerificationResult Parse();
    }
}