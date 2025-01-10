namespace WebApplication2.Serializer
{
    public interface IWebService<T>
    {
        Task<T> Get() { throw new NotImplementedException(); }
        Task<bool> Post(T model) { throw new NotImplementedException(); }
        Task<bool> Post(T model, Stream file) { throw new NotImplementedException(); }
        Task<bool> Post(T model, List<Stream> files) { throw new NotImplementedException(); }
    }
}
