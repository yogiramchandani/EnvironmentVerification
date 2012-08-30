using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    /// <summary>
    /// A resource verifier takes a connection to a system resource and performs a set of actions
    /// against them, eg: A file system verifier may take a file path (action), security rights (action),
    /// file modified date (action) and verify the actions against the file system
    /// 
    /// </summary>
    public interface IResourceVerifier
    {
        void AddConnectionToVerify(string key, IDictionary<string, string> actions);
        List<VerificationResult> GetVerificationStatus();
    }

    /// <summary>
    /// The abstract verifier holds the list of connections to be verified, it iterated through the list
    /// and verifies each connection, aggregates the results (constructs the messages) and returns a
    /// result list.
    /// </summary>
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
            
            // for each connection in the list
            foreach (var connection in connectionList)
            {
                VerificationResult resultType;
                var actions = connection.Item2;

                // if the action list is empty then raise an error
                if (actions == null || actions.Count == 0)
                {
                    resultType = new VerificationResult{Message = "The actions specified are invalid", Type = ResultType.Failure};
                }
                else
                {
                    // else verify the connection
                    resultType = Verify(connection);    
                }
                
                // construct the verification result message
                string message = ConstructMessage(connection, resultType);
                // aggregate the results
                result.Add(new VerificationResult {Type = resultType.Type, Message = message});
            }
            return result;
        }

        protected abstract VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple);

        protected virtual string ConstructMessage(Tuple<string, IDictionary<string, string>> tuple, VerificationResult result)
        {
            string itemIdentifier = string.IsNullOrWhiteSpace(tuple.Item1)
                                    ? "{Error reading the item's identifier, it may be empty or have the an invalid placeholder}"
                                    : tuple.Item1;

            return result.Type == ResultType.Failure
               ? string.Format("{0} verifying {1}, Error Message: {2}, {3}", result.Type.ToString(), itemIdentifier, result.Message, ConstructActionMessage(tuple.Item2))
               : string.Format("{0} verifying {1}, {2}", result.Type.ToString(), itemIdentifier, ConstructActionMessage(tuple.Item2));
        }

        protected virtual string ConstructActionMessage(IDictionary<string, string> actions)
        {
            var actionMessage = new StringBuilder();

            if (actions != null && actions.Count > 0)
            {
                actionMessage.AppendLine();
                actions.ToList().ForEach(action => actionMessage.AppendLine(string.Format("Key: {0}, Value: {1}", action.Key, action.Value)));
            }
            return actionMessage.ToString();
        }
    }
}