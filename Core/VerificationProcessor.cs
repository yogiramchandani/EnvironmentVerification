using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Takes a list of Resources, iterates through each resource in the list, gets the respective Verifier
    /// from a Verifier Factory and aggregates the result from the Verifier.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VerificationProcessor<T> : IVerificationProcessor<T> where T : class
    {
        private List<IResourceItem<T>> _resourceItems;
        private IResourceVerifierFactory<T> _factory;

        public VerificationProcessor(IResourceVerifierFactory<T> factory)
        {
            _factory = factory;
            _resourceItems = new List<IResourceItem<T>>();
        }

        public void AddResourceItems(List<IResourceItem<T>> resourceItems)
        {
            _resourceItems.AddRange(resourceItems);
        }

        public List<VerificationResult> ProcessResources()
        {
            var result = new List<VerificationResult>();
            var resourceVerifiers = new Dictionary<T, IResourceVerifier>();
            // Iterate through the Resource List
            foreach (IResourceItem<T> item in _resourceItems)
            {
                if (item.ItemType == null)
                {
                    result.Add(new VerificationResult{Message = "The Item Type field is null or mis-named please check the input", Type = ResultType.Failure});
                }
                else
                {
                    IResourceVerifier verifier;
                    // Check if the Verifier exists in the Dictionary
                    if (!resourceVerifiers.TryGetValue(item.ItemType, out verifier))
                    {
                        // if not exist in the dictionary then extract it from the factory and add it to the dictionary
                        verifier = _factory.GetVerifier(item.ItemType);
                        resourceVerifiers.Add(item.ItemType, verifier);
                    }
                    // A connection is a set of Actions to be performed against a Verifier
                    verifier.AddConnectionToVerify(item.Identifier, item.Actions);
                }
            }
            // Go through the dictionary of Verifiers and processes the Actions added to them
            resourceVerifiers.Values.ToList().ForEach(x => result.AddRange(x.GetVerificationStatus()));

            return result;
        }
    }

    public interface IVerificationProcessor<T>
    {
        void AddResourceItems(List<IResourceItem<T>> resourceItems);
        List<VerificationResult> ProcessResources();
    }
}