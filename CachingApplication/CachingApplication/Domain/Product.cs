using System;
using System.Collections.Generic;
using System.Text;

namespace CachingApplication.Domain
{
    public class Product
    {
        public int Id { get;}
        public string Name { get; }
        public double Price { get; }
        public string Description { get;}

        public Product(int id, string name, double price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
            => $"#{Id} {Name} - {Price:C} | {Description}";
    }
}
