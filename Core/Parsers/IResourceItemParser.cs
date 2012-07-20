using System.Collections.Generic;

namespace Core
{
    public interface IResourceItemParser<TResourceType, TFormat>
    {
        VerificationResult ParseResourceItems(TFormat raw);
        List<IResourceItem<TResourceType>> ResourceList { get; set; }
    }
}