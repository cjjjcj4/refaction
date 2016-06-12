using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Models;

namespace refactor_me.Services
{
    public class ProductsService : IProductsService
    {
        public void CreateOption(Guid productId, ProductOption option)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteOption(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Products GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductOption GetOptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductOptions GetOptionsByProductId(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Products SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}