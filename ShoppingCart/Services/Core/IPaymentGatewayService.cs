
using ShoppingCart.Models;

namespace ShoppingCart.Services.Core
{
    public interface IPaymentGatewayService
    {
        TransactionResult SubmitPayment(Order order);
    }
}
