using System;
using System.Collections.Generic;
using System.Text;
using CachingApplication.Domain;
using Microsoft.Extensions.Caching.Memory;

namespace CachingApplication.Cache
{
    public sealed class ProductCache
    {
        private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        private static string Key(int id) => $"product:{id}";

        public Product? Get(int id)
        {
            return _cache.TryGetValue(Key(id), out Product? product) ? product : null;
        }

        public void Set(Product product)
        {
            _cache.Set(
                Key(product.Id),
                product,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                }
            );
        }

        public void Remove(int id) => _cache.Remove(Key(id));
    }
}
