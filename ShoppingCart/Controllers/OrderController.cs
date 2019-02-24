using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public bool CreateOrder()
        {
            // TODO: add in proper exception handling
            var result = _paymentGatewayService.SubmitPayment();
            
            return result;
        }
    }
}