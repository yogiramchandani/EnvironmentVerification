namespace Core.SpecFlow
{
    public class ResourceItem : IResourceItem<string>
    {
        public string ItemType { get; set; }
        public string Identifier { get; set; }
        public string Location { get; set; }
    }

    public interface IResourceItem<T>
    {
        T ItemType { get; set; }
        string Identifier { get; set; }
        string Location { get; set; }
    }
}