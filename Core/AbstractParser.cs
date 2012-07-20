using System;

namespace Core
{
    public abstract class AbstractParser : IParser
    {
        public virtual VerificationResult Parse()
        {
            try
            {
                return Execute();
            }
            catch(Exception e)
            {
                return new VerificationResult { Message = ConstructExceptionMessage(e), Type = ResultType.Failure };
            }
        }

        public abstract VerificationResult Execute();

        public abstract string ConstructExceptionMessage(Exception e);
    }
}