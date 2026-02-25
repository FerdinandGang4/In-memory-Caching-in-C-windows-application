using CachingApplication.Cache;
using CachingApplication.Service;

namespace CachingApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cache = new ProductCache();
            var service = new ProductService(cache);

            Console.WriteLine(service.GetById(1));
            Console.WriteLine(service.GetById(1)); // should be HIT

            Console.WriteLine("\nUpdating price...\n");
            service.UpdatePrice(1, 59.99);

            Console.WriteLine(service.GetById(1)); // updated value
            Console.WriteLine(service.GetById(1)); // HIT
        }
    }
}
