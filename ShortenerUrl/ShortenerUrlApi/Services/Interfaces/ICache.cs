namespace ShortenerUrlApi.Services
{
    public interface ICache
    {
        string Get(string key);
        string Add(string key, string value);
    }
}