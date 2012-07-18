using System;
using System.IO;

namespace Core
{
    public class FileVerifier : ResourceVerifier
    { 
        protected override bool Verify(Tuple<string, string> tuple)
        {
            return File.Exists(tuple.Item2);
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("{0} connecting to {1}, file path: {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
        }
    }
}