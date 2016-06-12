using System;
using System.Collections.Generic;

namespace refactor_me.Models
{
    public class ProductOptions
    {
        public List<ProductOption> Items { get; private set; }

        public ProductOptions(List<ProductOption> items)
        {
            Items = items;
        }
    }

    public class ProductOption
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductOption()
        {
            Id = Guid.NewGuid();
        }

    }
}