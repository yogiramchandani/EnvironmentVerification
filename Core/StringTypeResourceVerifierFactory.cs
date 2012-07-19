namespace Core
{
    public class StringTypeResourceVerifierFactory : IResourceVerifierFactory<string>
    {
        public IResourceVerifier GetVerifier(string type)
        {
            if (type == "File")
            {
                return new FileVerifier();
            }
            if (type == "Directory")
            {
                return new DirectoryVerifier();
            }
            if (type == "Database")
            {
                return new DatabaseVerifier();
            }
            if (type == "WindowsService")
            {
                return new ServiceVerifier();
            }
            return new UnknownVerifier();
        }
    }

    public interface IResourceVerifierFactory<in T>
    {
        IResourceVerifier GetVerifier(T type);
    }
}