using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class TransactionResult
    {
        public Address DeliveryAddress { get; set; }

        public IList<Product> PurchasedItems { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public bool HasErrors => Errors.Any();
    }
}