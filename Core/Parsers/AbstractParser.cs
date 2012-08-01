using System;
using Ninject;
using Ninject.Extensions.Logging;

namespace Core
{
    public abstract class AbstractParser<T> : IParser where T:Exception
    {
        [Inject]
        public ILogger logger { protected get; set; }

        public virtual VerificationResult Parse()
        {
            try
            {
                return Execute();
            }
            catch(T e)
            {
                return new VerificationResult { Message = ConstructExceptionMessage(e), Type = ResultType.Failure };
            }
        }

        protected abstract VerificationResult Execute();

        protected abstract string ConstructExceptionMessage(T e);
    }

    public interface IParser
    {
        VerificationResult Parse();
    }
}