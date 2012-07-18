using System.Collections.Generic;

namespace Core
{
    public interface IResourceVerifier
    {
        void AddConnectionToVerify(string key, string connection);
        List<VerificationResult> GetVerificationStatus();
    }
}