using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortenerUrlApi.Services
{
    public class UrlHandler : IUrlHandler
    {
        private readonly ICache _cache;
        private readonly IRandomUrlGenerator _randomUrlGenerator;
        public UrlHandler(ICache cache, IRandomUrlGenerator randomUrlGenerator)
        {
            _cache = cache;
            _randomUrlGenerator = randomUrlGenerator;
        }
        public string Create(string url)
        {
            try
            {
                var randomString = _randomUrlGenerator.CreateCode();
                _cache.Add(randomString, url);
                return randomString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetUrl(string shortUrl)
        {
            try
            {
                return _cache.Get(shortUrl);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
