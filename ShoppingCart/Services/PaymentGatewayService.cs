using System.Linq;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        public TransactionResult SubmitPayment(Order order)
        {
            var result = new TransactionResult();

            if (!order.Items.Any())
            {
                result.Errors.Add("Invalid order: item count must be greater than zero.");
            }

            if (string.IsNullOrEmpty(order.PaymentInfo.CreditCard.CardNumber)
                || string.IsNullOrEmpty(order.PaymentInfo.CreditCard.Month)
                || string.IsNullOrEmpty(order.PaymentInfo.CreditCard.Year)
                || string.IsNullOrEmpty(order.PaymentInfo.CreditCard.CVV))
            {
                result.Errors.Add("Invalid or missing credit card number.");
            }

            if (string.IsNullOrEmpty(order.PaymentInfo.Address.Name)
                || string.IsNullOrEmpty(order.PaymentInfo.Address.Address1)
                || string.IsNullOrEmpty(order.PaymentInfo.Address.City)
                || string.IsNullOrEmpty(order.PaymentInfo.Address.State)
                || string.IsNullOrEmpty(order.PaymentInfo.Address.ZipCode)
                || string.IsNullOrEmpty(order.PaymentInfo.Address.Country))
            {
                result.Errors.Add("Invalid or missing address information.");
            }

            if(!result.Errors.Any())
            {
                // valid order
                result.PurchasedItems = order.Items;
                result.DeliveryAddress = order.PaymentInfo.Address;
            }

            return result;
        }
    }
}
