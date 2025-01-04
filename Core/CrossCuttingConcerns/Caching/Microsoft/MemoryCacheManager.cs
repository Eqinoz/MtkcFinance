using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ConcurrentBag<string> _cacheKeys; // Anahtarların tutulduğu bir koleksiyon


        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            _cacheKeys = new ConcurrentBag<string>();
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
            _cacheKeys.Add(key); // Anahtarı listeye ekle
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            // Anahtarı listeden çıkar
            var newKeys = _cacheKeys.Where(k => k != key).ToList();
            _cacheKeys.Clear();
            foreach (var k in newKeys)
            {
                _cacheKeys.Add(k);
            }
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = _cacheKeys.Where(k => regex.IsMatch(k)).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }

            // ConcurrentBag güncellenir
            var updatedKeys = _cacheKeys.Except(keysToRemove).ToList();
            _cacheKeys.Clear();
            foreach (var key in updatedKeys)
            {
                _cacheKeys.Add(key);
            }
        }


    }
}
