using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.Services.Core
{
    public interface IProductInventoryService
    {
        IEnumerable<Product> GetAvailableProducts();
    }
}
