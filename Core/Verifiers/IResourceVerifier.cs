using System.Collections.Generic;

namespace Core
{
    public interface IResourceVerifier
    {
        void AddConnectionToVerify(string key, IDictionary<string, string> actions);
        List<VerificationResult> GetVerificationStatus();
    }
}