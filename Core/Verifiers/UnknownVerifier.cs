using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class UnknownVerifier : AbstractResourceVerifier
    {
        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple)
        {
            return new VerificationResult {Type = ResultType.Failure};
        }

        protected override string ConstructMessage(Tuple<string, IDictionary<string, string>> tuple, VerificationResult result)
        {
            return string.Format("{0}: Could not find a valid verifier for the following elements: {1}{2}", result.Type.ToString(), Environment.NewLine, ConstructActionMessage(tuple.Item2));
        }
    }
}