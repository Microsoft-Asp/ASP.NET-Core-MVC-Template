using System;
using System.Threading.Tasks;
using Constants.Enums;

namespace Services.CacheService
{
    public interface ICacheService
    {
        Task<T> GetOrCreate<T>(CacheKeys key, Func<T> getItem, bool absoluteCache = false, bool updateCache = false, uint duration = 0);
        Task<T> GetOrCreate<T>(string keyString, Func<T> getItem, bool absoluteCache = false, bool updateCache = false, uint duration = 0);
    }
}