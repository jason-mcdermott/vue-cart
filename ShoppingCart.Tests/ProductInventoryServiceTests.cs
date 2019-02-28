using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.MockRepository.Core;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.Services.Core;
using Moq;
using System.Collections.Generic;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ProductInventoryServiceTests
    {
        // normally I wouldn't try to test a repository like this but since we're
        // already using a "MockRepository" it seems OK for now.
        // future refactor would be to 
        private Mock<IProductRepository> _repository;
        private IProductInventoryService _productService;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IProductRepository>();
            _productService = new ProductInventoryService(_repository.Object);
        }

        [TestMethod]
        public void GetAvailableProducts_returns_list_of_products()
        {
            // arrange
            _repository.Setup(repo => repo.GetProductList())
                .Returns(new List<Product>
                {
                    new Product { Id = "123", Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m },
                    new Product { Id = "234", Name = "Blue Jeans", Description = "Fancy new jeans", Price = 45.99m }
                });
            
            // act
            var products = _productService.GetAvailableProducts();

            // assert
            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void GetAvailableProducts_returns_typed_List_of_Product()
        {
            // arrange
            _repository.Setup(repo => repo.GetProductList())
                .Returns(new List<Product>
                {
                    new Product { Id = "123", Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m },
                });

            // act
            var products = _productService.GetAvailableProducts();

            // assert
            Assert.IsInstanceOfType(products, typeof(List<Product>));
            Assert.IsInstanceOfType(products.First(), typeof(Product));
        }
    }
}