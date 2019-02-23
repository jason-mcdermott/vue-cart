using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInventoryService _productInventoryService;

        public ProductController(IProductInventoryService productInventoryService)
        {
            _productInventoryService = productInventoryService;
        }

        [HttpGet]
        [Route("products")]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<Product> GetProducts()
        {
            // TODO: add in proper exception handling
            var products = _productInventoryService.GetAvailableProducts();
            
            return products;
        }
    }
}