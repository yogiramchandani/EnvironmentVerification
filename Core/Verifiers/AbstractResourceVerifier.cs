using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class AbstractResourceVerifier : IResourceVerifier
    {
        protected IList<Tuple<string, string>> connectionList;

        protected AbstractResourceVerifier()
        {
            connectionList = new List<Tuple<string, string>>();
        }

        public virtual void AddConnectionToVerify(string key, string connection)
        {
            connectionList.Add(new Tuple<string, string>(key, connection));
        }

        public virtual List<VerificationResult> GetVerificationStatus()
        {
            var result = new List<VerificationResult>();
            
            foreach (var tuple in connectionList)
            {
                ResultType resultType = Verify(tuple);

                string message = ConstructMessage(tuple, resultType);
                result.Add(new VerificationResult {Type = resultType, Message = message});
            }
            return result;
        }

        protected abstract ResultType Verify(Tuple<string, string> tuple);
        protected abstract string ConstructMessage(Tuple<string, string> tuple, ResultType canConnect);
    }
}