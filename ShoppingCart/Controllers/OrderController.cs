using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPaymentGatewayService _paymentGatewayService;

        public OrderController(IPaymentGatewayService paymentGatewayService)
        {
            _paymentGatewayService = paymentGatewayService;
        }

        [HttpPost]
        [Route("")]
        [EnableCors("AllowSpecificOrigin")]
        public TransactionResult SubmitOrder(Order order)
        {
            return _paymentGatewayService.SubmitPayment(order);
        }
    }
}