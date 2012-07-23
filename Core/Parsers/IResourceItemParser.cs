using System.Collections.Generic;

namespace Core
{
    public interface IResourceItemParser<TResourceType>
    {
        VerificationResult ParseResourceItems(string raw);
        List<IResourceItem<TResourceType>> ResourceList { get; set; }
    }
}