using System;

namespace Core
{
    public class UnknownVerifier : AbstractResourceVerifier
    {
        protected override ResultType Verify(Tuple<string, string> tuple)
        {
            return ResultType.Failure;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, ResultType resultType)
        {
            return string.Format("Failed, Could not find a valid verifier for name: {0}, location: {1}", tuple.Item1, tuple.Item2);
        }
    }
}