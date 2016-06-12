using refactor_me.Dao;
using refactor_me.Models;
using System;

namespace refactor_me.Services
{
    public class ProductsService : IProductsService
    {
        private ProductDao _productDao = new ProductDao();

        private ProductOptionDao _productOptionDao = new ProductOptionDao();

        public Products GetAllProducts()
        {
            return _productDao.LoadAllProducts();
        }

        public Products SearchProductsByName(string name)
        {
            return _productDao.LoadProductsByName(name);
        }

        public Product GetProductById(Guid id)
        {
            return _productDao.LoadProductById(id);
        }

        public void CreateProduct(Product product)
        {
            _productDao.AddProduct(product);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            _productDao.UpdateProduct(id, product);
        }

        public void DeleteProduct(Guid id)
        {
            _productDao.DeleteProduct(id);
        }

        public ProductOptions GetOptionsByProductId(Guid productId)
        {
            return _productOptionDao.LoadOptionsByProductId(productId);
        }

        public ProductOption GetOptionById(Guid productId, Guid id)
        {
            var product = GetProductById(productId);
            if (product == null)
            {
                throw new Exception("The product which the option belongs to dosen't exist");
            }
            var option = _productOptionDao.LoadOptionById(id);
            return option;
        }

        public void CreateOption(Guid productId, ProductOption option)
        {
            Product product = _productDao.LoadProductById(productId);
            if (product != null)
            {
                _productOptionDao.AddProductOption(productId, option);
            }
            else
            {
                throw new Exception("Product dosen't exist.");
            }

        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            _productOptionDao.UpdateProductOption(id, option);
        }

        public void DeleteOption(Guid id)
        {
            _productOptionDao.DeleteOptionById(id);
        }

    }
}
