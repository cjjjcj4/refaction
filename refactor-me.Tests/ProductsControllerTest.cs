using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using refactor_me.Controllers;
using refactor_me.Models;

namespace refactor_me.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        #region Product test cases
        [TestMethod]
        public void GetAllProducts()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            Products result = controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchProductsByName()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            var result = controller.SearchByName("Samsung Galaxy S7");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProductById()
        {
            // Arrange
            var controller = new ProductsController();
            Guid id = getTestProductGuid();

            // Act
            var result = controller.GetProduct(id);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateAndDeleteProduct()
        {
            //---Create---

            // Arrange
            var controller = new ProductsController();
            var name = "cjtest";
            Product product = new Product();
            product.Name = name;

            // Act
            controller.Create(product);

            var value = controller.GetProduct(product.Id);
            // Assert
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Id == product.Id);

            //---Delete---

            // Act
            controller.Delete(product.Id);

            var valueAfterDelete = controller.GetProduct(product.Id);
            // Assert
            Assert.IsNull(valueAfterDelete);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            // Arrange
            var controller = new ProductsController();
            Guid id = getTestProductGuid();
            Product product = controller.GetProduct(id);
            product.Name = "updatedName";

            // Act
            controller.Update(id, product);

            var value = controller.GetProduct(id);
            // Assert
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Name == "updatedName");
        }
        #endregion

        #region Product option test cases
        [TestMethod]
        public void GetOptionsByProductId()
        {
            // Arrange
            var controller = new ProductsController();

            // Act
            ProductOptions result = controller.GetOptions(getTestProductGuid());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateGetUpdateDeleteOption()
        {
            // Arrange
            var controller = new ProductsController();
            var name = "cjtest";
            var updatedName = "updated";
            ProductOption option = new ProductOption();
            option.Name = name;

            // Act
            controller.CreateOption(getTestProductGuid(), option);
            ProductOption result = controller.GetOption(getTestProductGuid(), option.Id);

            // Assert
            Assert.IsNotNull(result);

            //Act
            result.Name = updatedName;
            controller.UpdateOption(option.Id, result);

            ProductOption resultUpdated = controller.GetOption(getTestProductGuid(), option.Id);

            //Assert
            Assert.AreEqual(updatedName, resultUpdated.Name);

            //Act
            controller.DeleteOption(option.Id);

            // Assert
            Assert.IsNull(controller.GetOption(getTestProductGuid(), option.Id));

        }
        #endregion

        #region helper
        private Guid getTestProductGuid()
        {
            return Guid.Parse("8f2e9176-35ee-4f0a-ae55-83023d2db1a3");
        }
        #endregion
    }
}
