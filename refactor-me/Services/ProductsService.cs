using refactor_me.Dao;
using refactor_me.Models;
using System;
using System.Net;
using System.Web.Http;

namespace refactor_me.Services
{
    public class ProductsService : IProductsService
    {
        private ProductDao _productDao = new ProductDao();

        private ProductOptionDao _productOptionDao = new ProductOptionDao();

        public Products GetAllProducts()
        {
            return _productDao.loadAllProducts();
        }

        public Products SearchProductsByName(string name)
        {
            return _productDao.loadProductsByName(name);
        }

        public Product GetProductById(Guid id)
        {
            return _productDao.loadProductById(id);
        }

        public void CreateProduct(Product product)
        {
            if (product.Name == null)
            {
                throw new Exception("Product name is null.");
            }
            _productDao.addProduct(product);
        }

        public void UpdateProduct(Guid id, Product product)
        {
            _productDao.updateProduct(id, product);
        }

        public void DeleteProduct(Guid id)
        {
            _productOptionDao.deleteOptionsByProductId(id);
            _productDao.deleteProduct(id);
        }

        public ProductOptions GetOptionsByProductId(Guid productId)
        {
            return _productOptionDao.loadOptionsByProductId(productId);
        }

        public ProductOption GetOptionById(Guid id)
        {
            var option = _productOptionDao.loadOptionById(id);
            return option;
        }

        public void CreateOption(Guid productId, ProductOption option)
        {
            Product product = _productDao.loadProductById(productId);
            if (product != null)
            {
                _productOptionDao.addProductOption(productId, option);
            }
            else
            {
                throw new Exception("Product dosen't exist.");
            }

        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            _productOptionDao.updateProductOption(id, option);
        }

        public void DeleteOption(Guid id)
        {
            _productOptionDao.deleteOptionById(id);
        }

    }
}
