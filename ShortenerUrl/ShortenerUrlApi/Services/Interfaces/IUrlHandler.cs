namespace ShortenerUrlApi.Services
{
    public interface IUrlHandler
    {
        string Create(string url);
        string GetUrl(string shortUrl);
    }
}