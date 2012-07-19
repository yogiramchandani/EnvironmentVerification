using System.Collections.Generic;

namespace Core
{
    public interface IResourceItemProcessor<TResourceType, TFormat>
    {
        void ParseResourceItems(TFormat json);
        List<IResourceItem<TResourceType>> GetResourceList();
    }
}