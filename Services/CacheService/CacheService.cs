using System;
using System.Threading;
using System.Threading.Tasks;
using Constants.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly uint _defaultExpiration;
        private readonly SemaphoreSlim _locker;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IMemoryCache cache,
                            IConfiguration config,
                            ILogger<CacheService> logger)
        {
            _cache = cache;
            _defaultExpiration = uint.Parse(config["CacheExpirationMinutes"]);
            _locker = new SemaphoreSlim(1, 1);
            _logger = logger;
        }

        public async Task<T> GetOrCreate<T>(CacheKeys key, Func<T> getItem, bool absoluteCache = false, bool updateCache = false, uint duration = 0)
        {
            var keyString = Enum.GetName(typeof(CacheKeys), key);
            return await GetOrCreate(keyString, getItem, absoluteCache, updateCache, duration);
        }

        public async Task<T> GetOrCreate<T>(string keyString, Func<T> getItem, bool absoluteCache = false, bool updateCache = false, uint duration = 0)
        {
            duration = duration > 0 ? duration : _defaultExpiration;
            var item = _cache.Get<T>(keyString);

            if (item == null || updateCache)
            {
                try
                {
                    await _locker.WaitAsync();
                    item = _cache.GetOrCreate(keyString, entry => new Lazy<T>(() =>
                    {
                        if (absoluteCache)
                            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(duration));
                        else
                            entry.SetSlidingExpiration(TimeSpan.FromMinutes(duration));

                        return getItem();
                    }).Value);
                }
                catch (Exception exc)
                {
                    _logger.LogError($"Error adding new cache item. Stack trace: {exc.ToString()}");
                }
                finally
                {
                    _locker.Release();
                }
            }

            return item;
        }


    }
}