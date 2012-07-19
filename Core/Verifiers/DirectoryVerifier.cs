using System;
using System.IO;

namespace Core
{
    public class DirectoryVerifier : AbstractResourceVerifier
    {
        protected override ResultType Verify(Tuple<string, string> tuple)
        {
            return Directory.Exists(tuple.Item2) ? ResultType.Success : ResultType.Failure;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, ResultType resultType)
        {
            return string.Format("{0} connecting to {1}, path: {2}", resultType.ToString(), tuple.Item1, tuple.Item2);
        }
    }
}