using CachingApplication.Cache;
using CachingApplication.Domain;

namespace CachingApplication.Service
{
    public sealed class ProductService
    {
        private readonly ProductCache _cache;

        // Fake database
        private readonly List<Product> _db = new()
        {
            new Product(1, "Keyboard", 49.99, "Mechanical keyboard"),
            new Product(2, "Mouse", 19.99, "Wireless mouse"),
            new Product(3, "Monitor", 199.99, "27-inch display"),
        };

        public ProductService(ProductCache cache)
        {
            _cache = cache;
        }

        public Product? GetById(int id)
        {
            // 1) Try cache
            var cached = _cache.Get(id);
            if (cached != null)
            {
                Console.WriteLine("CACHE HIT");
                return cached;
            }

            Console.WriteLine("CACHE MISS");

            // 2) Load from “db”
            var product = _db.FirstOrDefault(p => p.Id == id);
            if (product == null) return null;

            // 3) Store in cache
            _cache.Set(product);

            return product;
        }

        public void UpdatePrice(int id, double newPrice)
        {
            var index = _db.FindIndex(p => p.Id == id);
            if (index < 0) return;

            var old = _db[index];
            var updated = new Product(old.Id, old.Name, newPrice, old.Description);

            _db[index] = updated;

            // Invalidate and refresh cache
            _cache.Remove(id);
            _cache.Set(updated);
        }
    }
}