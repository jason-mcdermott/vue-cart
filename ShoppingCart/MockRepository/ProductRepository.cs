using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ShoppingCart.MockRepository.Core;
using ShoppingCart.Models;

namespace ShoppingCart.MockRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connection;

        public ProductRepository(string connection)
        {
            _connection = connection;
        }
            
        public IList<Product> GetProductList()
        {
            
            List<Product> products = new List<Product>();
            using (StreamReader reader = new StreamReader(_connection))
            {
                string json = reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json);
            }

            return products;
        }
    }
}