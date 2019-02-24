using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Order
    {
        public IList<Product> Items { get; set; }

        public PaymentInfo PaymentInfo { get; set; }
    }
}
