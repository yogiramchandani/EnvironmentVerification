using System.Collections.Generic;

namespace Core
{
    public interface IResourceItemParser<TResourceType, TFormat>
    {
        void ParseResourceItems(TFormat raw);
        List<IResourceItem<TResourceType>> GetResourceList();
    }
}