using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.MockRepository.Core
{
    public interface IProductRepository
    {
        IList<Product> GetProductList();
    }
}