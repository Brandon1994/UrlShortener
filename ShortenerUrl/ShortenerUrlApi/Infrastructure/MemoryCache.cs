using ShortenerUrlApi.Services;
using System.Collections.Generic;

namespace ShortenerUrlApi.Infrastructure
{
    public class MemoryCache : ICache
    {
        private static Dictionary<string, string> urlDictionary { get; set; }

        public MemoryCache()
        {
            urlDictionary = new Dictionary<string, string>();
        }
        public string Add(string key, string value)
        {
            urlDictionary.Add(key, value);
            return key;
        }

        public string Get(string key)
        {
            return urlDictionary.GetValueOrDefault(key);
        }
    }
}
