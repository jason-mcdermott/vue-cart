using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        public IEnumerable<Product> GetAvailableProducts()
        {
            // if any issues with retrieving data from products.json, uncomment this code:
            //
            //var products = new List<Product>();
            //products.Add(new Product { Id = 1, Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m });
            //products.Add(new Product { Id = 2, Name = "Widget", Description = "Shiny new widget", Price = 5.95m });
            //products.Add(new Product { Id = 3, Name = "Pencil Case", Description = "Standard Issue Pencil Case", Price = 64.95m });
            
            var products = GetMockData("MockRepository/products.json");

            return products as IEnumerable<Product>;
        }

        private IList<Product> GetMockData(string path)
        {
            List<Product> products = new List<Product>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }

            return products;
        }

    }
}
