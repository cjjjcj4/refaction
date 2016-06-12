using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using refactor_me.Services;
using System.Net.Http;
using refactor_me.Utilities;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductsService _productsService = new ProductsService();

        #region Product actions
        [Route]
        [HttpGet]
        public Products GetAll()
        {
            return _productsService.GetAllProducts();
        }

        [Route]
        [HttpGet]
        public Products SearchByName(string name)
        {
            return _productsService.SearchProductsByName(name);
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            return _productsService.GetProductById(id);
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            if (product == null || product.Name == null)
            {
                string errMessage = product == null ? "Product cannot be null." : "Product name cannot be null.";
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, errMessage);
                throw new HttpResponseException(response);
            }
            _productsService.CreateProduct(product);
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            if (product == null || product.Name == null)
            {
                string errMessage = product == null ? "Product cannot be null." : "Product name cannot be null.";
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, errMessage);
                throw new HttpResponseException(response);
            }
            _productsService.UpdateProduct(id, product);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);
            } catch (Exception)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, "Delete failed, please try again.");
                throw new HttpResponseException(response);
            }

        }
        #endregion

        #region Product option actions
        [Route("{productId}/options")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return _productsService.GetOptionsByProductId(productId);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var option = new ProductOption();
            try
            {
                option = _productsService.GetOptionById(productId, id);
            } catch (Exception)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, string.Format("Product with Id = {0} not found.", productId));
                throw new HttpResponseException(response);
            }
            return option;
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            if (option == null)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, "Option cannot be null.");
                throw new HttpResponseException(response);
            }
            try
            {
                _productsService.CreateOption(productId, option);
            }
            catch (Exception)
            {
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, string.Format("Product with Id = {0} not found.", productId));
                throw new HttpResponseException(response);
            }

        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            if (option == null || option.Name == null)
            {
                string errMessage = option == null ? "Option cannot be null." : "Option name cannot be null.";
                var response = HttpResponseFactory.ConstructResponse(HttpStatusCode.BadRequest, errMessage);
                throw new HttpResponseException(response);
            }
            _productsService.UpdateOption(id, option);
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            _productsService.DeleteOption(id);
        }
        #endregion
    }
}
