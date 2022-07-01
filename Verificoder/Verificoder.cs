namespace Verificoder
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;

    public class Verificoder : IVerificoder
    {
        private readonly VerificoderOptions _options;
        private readonly IMemoryCache _memoryCache;


        public Verificoder(IOptions<VerificoderOptions> options, IMemoryCache memCache)
        {
            _options = options.Value;
            _memoryCache = memCache;
        }


        #region Helpers
        private void EnsureConfiguration(int length, int maxRepeatNumber)
        {
            if (length == 0)
                throw new ArgumentException("length can not be zero.");

            if (length < 1 && length > 8)
                throw new ArgumentException("length must between 1 and 8.");

            if (maxRepeatNumber > length)
                throw new ArgumentException("maxRepeatNumber mus lower than length.");
        }

        private string Generator(int length, int maxRepeatNumber)
        {
            // throw clear exception
            EnsureConfiguration(length, maxRepeatNumber);

            var digits = new List<int>(length);

            for (int index = 0; index < length; index++)
            {
                int digit;

                do
                {
                    digit = new Random().Next((_options.StartWithZero || index != 0 ? 0 : 1), 9);
                }
                while (digits.Any(d => d == digit) &&
                        digits.Where(d => d == digit).Count() >= maxRepeatNumber);

                digits.Add(digit);
            }

            return string.Join("", digits);
        }

        private void AddToCache(string key, string code)
        {
            _memoryCache.Remove(key);

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.Normal)
                .SetAbsoluteExpiration(_options.ScopeCodeAbsoluteExpiration);

            _memoryCache.Set(key, code, memoryCacheEntryOptions);
        }
        #endregion

        public string TakeOne()
        {
            return Generator(_options.DefaultLength,
                _options.DefualtMaxRepeatNumber);
        }

        public string TakeOne(int length)
        {
            return Generator(length,
                  _options.DefualtMaxRepeatNumber);
        }

        public string TakeOne(int length, int maxRepeatNumber)
        { 
            return Generator(length,
                  maxRepeatNumber);
        }
         
        public string TakeOnScope(string key)
        {
            var code = TakeOne();

            AddToCache(key, code);
            return code;
        }

        public string TakeOnScope(string key,int length)
        {
            var code = TakeOne(length);

            AddToCache(key, code);
            return code;
        }

        public string TakeOnScope(string key, int length, int maxRepeatNumber)
        {
            var code = TakeOne(length, maxRepeatNumber);

            AddToCache(key, code);

            return code;
        }

        public bool IsValidOnScope(string key, string code)
        {
            if (_memoryCache.TryGetValue(key, out string _code))
            {
                return code == _code;
            }

            return false;
        }

        public bool CanTakeOnScope(string key) 
        {
            // after cacher entry you can take new code
            return !_memoryCache.TryGetValue(key, out string _);
        }
    }
}
