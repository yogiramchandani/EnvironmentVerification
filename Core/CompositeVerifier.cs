using System.Collections.Generic;
using Ninject;

namespace Core
{
    /// <summary>
    /// On receiving a Parsed resource blob, the Composite verifier extracts a list of
    /// resources using a format parser (eg: a Json Parser). It then sends the list for 
    /// verification through a processor, aggregates the result and returns it to the caller.
    /// </summary>
    /// <typeparam name="TResourceType">This generic type defines the Item Type representation</typeparam>
    public class CompositeVerifier<TResourceType> : IVerificationInvoker
    {
        [Inject]
        public ILog Logger { get; set; }
        readonly IResourceItemParser<TResourceType> _formatParser;
        readonly IVerificationProcessor<TResourceType> _processor;

        public CompositeVerifier( IResourceItemParser<TResourceType> formatParser, 
                                    IVerificationProcessor<TResourceType> processor)
        {
            _formatParser = formatParser;
            _processor = processor;
        }

        public List<VerificationResult> VerifyEnvironment(VerificationResult validationResult)
        {
            var result = new List<VerificationResult>();
            // Extract the list of resources to verify
            if (validationResult.Type == ResultType.Success)
            {
                validationResult = _formatParser.ParseResourceItems(validationResult.Message);
            }
            // if successful, process the list and aggregate the results
            if (validationResult.Type == ResultType.Success)
            {
                var resourceList = _formatParser.ResourceList;
                
                _processor.AddResourceItems(resourceList);
                result = _processor.ProcessResources();
            }
            // if the extraction Failed then aggregate the failure results
            if (validationResult.Type != ResultType.Success)
            {
                result.Add(validationResult);
            }
            return result;
        }
    }

    public interface IVerificationInvoker
    {
        ILog Logger { get; set; }
        List<VerificationResult> VerifyEnvironment(VerificationResult validationResult);
    }
}