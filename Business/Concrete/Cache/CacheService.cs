using Business.Abstract.Cache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Concrete.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _database;

        public RedisCacheService()
        {
            var connection = ConnectionMultiplexer.Connect("localhost:6379");
            _database = connection.GetDatabase();
        }
        public T Get<T>(string key)
        {
            var value = _database.StringGet(key);
            if (value.IsNullOrEmpty) return default;

            return JsonSerializer.Deserialize<T>(value);
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            if (value == null) return;

            var jsonValue = JsonSerializer.Serialize(value);
            _database.StringSet(key, jsonValue, expiration);
        }
    }

    public class MemCacheService : ICacheService
    {
        private readonly MemoryCache _cache;

        public MemCacheService()
        {
            _cache = MemoryCache.Default;
        }

        public T Get<T>(string key)
        {
            if (_cache.Contains(key))
            {
                Console.WriteLine("cacheden geldi");
                return (T)_cache.Get(key);
            }
            return default;
        }

        public void Remove(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            if (value == null) return;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = expiration.HasValue
                    ? DateTimeOffset.Now.Add(expiration.Value)
                    : ObjectCache.InfiniteAbsoluteExpiration
            };

            _cache.Set(key, value, policy);
        }
    }
}
