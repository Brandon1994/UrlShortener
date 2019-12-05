using ShortenerUrlApi.Services;
using System;

namespace ShortenerUrlApi.Infrastructure
{
    public class RandomUrlGenerator : IRandomUrlGenerator
    {
        public string CreateCode()
        {
            var rand = new Random();
            var randoString = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                randoString = string.Concat(randoString, rand.Next(1, 10));
            }
            return randoString;
        }
    }
}
