using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("products")]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { Name = "Sweater", Description = "Agora Wool Sweater", Price = 64.95m });
            products.Add(new Product { Name = "Widget", Description = "Shiny new widget", Price = 5.95m });
            products.Add(new Product { Name = "Pencil Case", Description = "Standard Issue Pencil Case", Price = 64.95m });

            return products as IEnumerable<Product>;
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}