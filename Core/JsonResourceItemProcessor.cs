using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core
{
    public class JsonResourceItemProcessor : IResourceItemProcessor<string, string>
    {
        private List<IResourceItem<string>> _resourceList;

        public JsonResourceItemProcessor()
        {
            _resourceList = new List<IResourceItem<string>>();
        }

        public void ParseResourceItems(string json)
        {
            var list = JsonConvert.DeserializeObject<List<ResourceItem>>(json);
            _resourceList.AddRange(list);
        }

        public List<IResourceItem<string>> GetResourceList()
        {
            return _resourceList;
        }
    }
}