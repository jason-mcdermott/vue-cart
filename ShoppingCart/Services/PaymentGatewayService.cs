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

            /* in order to test error display, uncomment this code: */
            //var result = new TransactionResult();
            //result.Errors.Add("Something bad happened.");
            //result.Errors.Add("Something else bad happened.");
            //return result;
        }
    }
}
