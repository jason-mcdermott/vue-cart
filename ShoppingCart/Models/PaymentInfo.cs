using System;

namespace ShoppingCart.Models
{
    public class PaymentInfo
    {
        public CreditCardInfo CreditCard { get; set; }

        public Address BillingAddress { get; set; }

        public Address DeliveryAddress { get; set; }

        public bool DeliverToBillingAddress { get; set; }
    }

    public class CreditCardInfo
    {
        public string Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CVV { get; set; }
    }

    public class Address
    {
        public string Recipient { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
