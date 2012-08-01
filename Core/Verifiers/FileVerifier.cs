using System;
using System.Collections.Generic;
using System.IO;

namespace Core
{
    public class FileVerifier : AbstractResourceVerifier
    {
        private string FilePath = "FilePath";

        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple)
        {
            string filePath;
            if (!tuple.Item2.TryGetValue(FilePath, out filePath))
            {
                return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Key {0} not found", FilePath) };
            }
            return File.Exists(filePath)
                       ? new VerificationResult { Type = ResultType.Success }
                       : new VerificationResult { Type = ResultType.Failure, Message = "File not found" };
        }
    }
}