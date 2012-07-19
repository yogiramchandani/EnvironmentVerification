using System;

namespace Core
{
    public class UnknownVerifier : AbstractResourceVerifier
    {
        protected override bool Verify(Tuple<string, string> tuple)
        {
            return false;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("Failed, Could not find a valid verifier for name: {0}, location: {1}", tuple.Item1, tuple.Item2);
        }
    }
}