using System;
using System.Collections.Generic;
using System.Text;

namespace CachingApplication.Domain
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, double price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
