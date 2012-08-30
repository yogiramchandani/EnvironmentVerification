using System;
using System.Collections.Generic;

namespace Core
{
    public class UnknownVerifier : AbstractResourceVerifier
    {
        protected string VerifierName { get; set; }

        public UnknownVerifier(string verifierName)
        {
            VerifierName = verifierName;
        }

        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple)
        {
            return new VerificationResult {Type = ResultType.Failure};
        }

        protected override string ConstructMessage(Tuple<string, IDictionary<string, string>> tuple, VerificationResult result)
        {
            return string.Format("{0}: Could not find a valid verifier for '{1}' with the following elements: {2}", result.Type.ToString(), VerifierName, ConstructActionMessage(tuple.Item2));
        }
    }
}