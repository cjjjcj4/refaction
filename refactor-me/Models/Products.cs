using System;
using System.Collections.Generic;

namespace refactor_me.Models
{
    public class Products
    {
        public List<Product> Items { get; private set; }

        public Products(List<Product> items)
        {
            Items = items;
        }

    }

    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }

    }

}