using refactor_me.Models;
using System;

namespace refactor_me.Services
{
    public interface IProductsService
    {
        Products GetAllProducts();
        Products SearchProductsByName(string name);
        Product GetProductById(Guid id);
        void CreateProduct(Product product);
        void UpdateProduct(Guid id, Product product);
        void DeleteProduct(Guid id);

        ProductOptions GetOptionsByProductId(Guid productId);
        ProductOption GetOptionById(Guid id);
        void CreateOption(Guid productId, ProductOption option);
        void UpdateOption(Guid id, ProductOption option);
        void DeleteOption(Guid id);
    }
}