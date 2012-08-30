using System;
using System.Collections.Generic;
using System.IO;

namespace Core
{
    public class DirectoryVerifier : AbstractResourceVerifier
    {
        private string DirectoryPath = "DirectoryPath";

        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> directoryItems)
        {
            string directoryPath;
            if (!directoryItems.Item2.TryGetValue(DirectoryPath, out directoryPath))
            {
                return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Key {0} not found", DirectoryPath) };
            }
            return Directory.Exists(directoryPath)
                       ? new VerificationResult {Type = ResultType.Success}
                       : new VerificationResult { Type = ResultType.Failure, Message = "Directory not found"};
        }
    }
}