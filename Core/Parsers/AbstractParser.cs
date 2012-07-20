using System;

namespace Core
{
    public abstract class AbstractParser<T> : IParser where T:Exception
    {
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