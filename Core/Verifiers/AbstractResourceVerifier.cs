using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class AbstractResourceVerifier : IResourceVerifier
    {
        protected IList<Tuple<string, IDictionary<string, string>>> connectionList;

        protected AbstractResourceVerifier()
        {
            connectionList = new List<Tuple<string, IDictionary<string, string>>>();
        }

        public virtual void AddConnectionToVerify(string key, IDictionary<string, string> actions)
        {
            connectionList.Add(new Tuple<string, IDictionary<string, string>>(key, actions));
        }

        public virtual List<VerificationResult> GetVerificationStatus()
        {
            var result = new List<VerificationResult>();
            
            foreach (var tuple in connectionList)
            {
                VerificationResult resultType = Verify(tuple);

                string message = ConstructMessage(tuple, resultType);
                result.Add(new VerificationResult {Type = resultType.Type, Message = message});
            }
            return result;
        }

        protected abstract VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple);

        protected virtual string ConstructMessage(Tuple<string, IDictionary<string, string>> tuple, VerificationResult result)
        {
            return result.Type == ResultType.Failure
               ? string.Format("{0} connecting to {1}, Error Message: {2}, {3}", result.Type.ToString(), tuple.Item1, result.Message, ConstructActionMessage(tuple.Item2))
               : string.Format("{0} connecting to {1}, {2}", result.Type.ToString(), tuple.Item1, ConstructActionMessage(tuple.Item2));
        }

        protected virtual string ConstructActionMessage(IDictionary<string, string> actions)
        {
            var actionMessage = new StringBuilder();
            foreach (KeyValuePair<string, string> action in actions)
            {
                actionMessage.AppendLine(string.Format("Key: {0}, Value: {1}", action.Key, action.Value));
            }

            return actionMessage.ToString();
        }
    }
}