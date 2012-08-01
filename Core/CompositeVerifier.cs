using System.Collections.Generic;

namespace Core
{
    public class CompositeVerifier<TResourceType> : IVerificationInvoker
    {
        readonly IResourceItemParser<TResourceType> _parser;
        readonly IVerificationProcessor<TResourceType> _processor;

        public CompositeVerifier( IResourceItemParser<TResourceType> parser, 
                                    IVerificationProcessor<TResourceType> processor)
        {
            _parser = parser;
            _processor = processor;
        }

        public List<VerificationResult> VerifyEnvironment(VerificationResult validationResult)
        {
            var result = new List<VerificationResult>();
            if (validationResult.Type == ResultType.Success)
            {
                validationResult = _parser.ParseResourceItems(validationResult.Message);
            }
            if (validationResult.Type == ResultType.Success)
            {
                var resourceList = _parser.ResourceList;
                
                _processor.AddResourceItems(resourceList);
                result = _processor.ProcessResources();
            }
            if (validationResult.Type != ResultType.Success)
            {
                result.Add(validationResult);
            }
            return result;
        }
    }

    public interface IVerificationInvoker
    {
        List<VerificationResult> VerifyEnvironment(VerificationResult validationResult);
    }
}