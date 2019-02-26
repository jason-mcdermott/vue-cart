using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        public TransactionResult SubmitPayment(Order order)
        {
            return new TransactionResult
            {
                PurchasedItems = order.Items,
                DeliveryAddress = order.PaymentInfo.Address
            };

            //var result = new TransactionResult();
            //result.Errors.Add("Something bad happened.");

            //return result;
        }
    }
}
