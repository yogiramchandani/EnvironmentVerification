using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core
{
    public class JsonResourceItemParser : IResourceItemParser<string, string>
    {
        private List<IResourceItem<string>> _resourceList;

        public JsonResourceItemParser()
        {
            _resourceList = new List<IResourceItem<string>>();
        }

        public void ParseResourceItems(string raw)
        {
            var list = JsonConvert.DeserializeObject<List<ResourceItem>>(raw);
            _resourceList.AddRange(list);
        }

        public List<IResourceItem<string>> GetResourceList()
        {
            return _resourceList;
        }
    }
}