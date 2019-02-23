using System.Collections.Generic;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        public IEnumerable<Product> GetAvailableProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m });
            products.Add(new Product { Name = "Widget", Description = "Shiny new widget", Price = 5.95m });
            products.Add(new Product { Name = "Pencil Case", Description = "Standard Issue Pencil Case", Price = 64.95m });

            return products as IEnumerable<Product>;
        }
    }
}
