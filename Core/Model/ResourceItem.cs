using System.Collections.Generic;

namespace Core
{
    public class ResourceItem : IResourceItem<string>
    {
        public string ItemType { get; set; }
        public string Identifier { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }

    public interface IResourceItem<TItemType>
    {
        TItemType ItemType { get; set; }
        string Identifier { get; set; }
        IDictionary<string, string> Actions { get; set; }
    }
}