using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class ResourceVerifier : IResourceVerifier
    {
        protected IList<Tuple<string, string>> connectionList;

        protected ResourceVerifier()
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
                bool canConnect = Verify(tuple);

                string message = ConstructMessage(tuple, canConnect);
                result.Add(new VerificationResult {CanConnect = canConnect, Message = message});
            }
            return result;
        }

        protected abstract bool Verify(Tuple<string, string> tuple);
        protected abstract string ConstructMessage(Tuple<string, string> tuple, bool canConnect);
    }
}