using System.Collections.Generic;
using System.Linq;

namespace Core
{
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
            foreach (IResourceItem<T> item in _resourceItems)
            {
                if (item.ItemType == null)
                {
                    result.Add(new VerificationResult{Message = "The Item Type field is null or mis-named please check the input", Type = ResultType.Failure});
                }
                else
                {
                    IResourceVerifier verifier;
                    if (!resourceVerifiers.TryGetValue(item.ItemType, out verifier))
                    {
                        verifier = _factory.GetVerifier(item.ItemType);
                        resourceVerifiers.Add(item.ItemType, verifier);
                    }
                    verifier.AddConnectionToVerify(item.Identifier, item.Actions);
                }
            }
            
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