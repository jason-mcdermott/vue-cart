using ShoppingCart.Services.Core;

namespace ShoppingCart.Services
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        public bool SubmitPayment()
        {
            // TODO: add Thread.Sleep() to simulate time it takes to properly validate
            // and submit a payment. Make sure to display a spinner on the Vue view.
            return true;
        }
    }
}
