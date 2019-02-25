using System;

namespace ShoppingCart.Models
{
    public class PaymentInfo
    {
        public CreditCard CreditCard { get; set; }

        public Address Address { get; set; }
    }
}
