using System;
using System.IO;

namespace Core
{
    public class DirectoryVerifier : AbstractResourceVerifier
    {
        protected override bool Verify(Tuple<string, string> tuple)
        {
            return Directory.Exists(tuple.Item2);
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("{0} connecting to {1}, path: {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
        }
    }
}