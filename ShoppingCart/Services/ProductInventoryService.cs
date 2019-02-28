using System.Collections.Generic;
using ShoppingCart.MockRepository.Core;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IProductRepository _repository;

        public ProductInventoryService(IProductRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Product> GetAvailableProducts()
        {
            /* if you have any issues with retrieving data from products.json, uncomment this code: */
            //var products = new List<Product>();
            //products.Add(new Product { Id = 1, Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m });
            //products.Add(new Product { Id = 2, Name = "Widget", Description = "Shiny new widget", Price = 5.95m });
            //products.Add(new Product { Id = 3, Name = "Pencil Case", Description = "Standard Issue Pencil Case", Price = 64.95m });

            var products = _repository.GetProductList();

            return products as IEnumerable<Product>;
        }
    }
}
