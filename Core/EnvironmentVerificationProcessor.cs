using System.Collections.Generic;
using System.Linq;
using Core.SpecFlow;

namespace Core
{
    public class EnvironmentVerificationProcessor<T>
    {
        private List<IResourceItem<T>> _resourceItems;
        private IResourceVerifierFactory<T> _factory;

        public EnvironmentVerificationProcessor(IResourceVerifierFactory<T> factory)
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
            var resourceVerifiers = new Dictionary<T, IResourceVerifier>();
            foreach (IResourceItem<T> item in _resourceItems)
            {
                IResourceVerifier verifier;
                if (!resourceVerifiers.TryGetValue(item.ItemType, out verifier))
                {
                    verifier = _factory.GetVerifier(item.ItemType);
                    resourceVerifiers.Add(item.ItemType, verifier);
                }
                verifier.AddConnectionToVerify(item.Identifier, item.Location);
            }

            var result = new List<VerificationResult>();
            resourceVerifiers.Values.ToList().ForEach(x => result.AddRange(x.GetVerificationStatus()));

            return result;
        }
    }
}