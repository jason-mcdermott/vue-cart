using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.Services.Core;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class PaymentGatewayServiceTests
    {
        private IPaymentGatewayService _paymentService;
        private PaymentInfo _paymentInfo;

        [TestInitialize]
        public void TestInitialize()
        {
            _paymentService = new PaymentGatewayService();

            _paymentInfo = new PaymentInfo
            {
                CreditCard =
                    new CreditCard
                    {
                        CardNumber = "1234",
                        Month = "01",
                        Year = "1999",
                        CVV = "123"
                    },
                Address =
                    new Address
                    {
                        Name = "Doug Crockford",
                        Address1 = "123 Main St.",
                        City = "Minneapolis",
                        State = "MN",
                        ZipCode = "12345",
                        Country = "USA"
                    }
            };
        }

        [TestMethod]
        public void SubmitPayment_returns_TransactionResult_without_errors_for_valid_order()
        {
            // arrange
            var order = new Order();
            order.Items.Add(new Product { Id = "ABC", Name = "Widget 1", Description = "A widget", Price = 1.99m });
            order.Items.Add(new Product { Id = "DEF", Name = "Widget 2", Description = "Another widget", Price = 3.99m });
            order.PaymentInfo = _paymentInfo;
            
            // act
            var result = _paymentService.SubmitPayment(order);

            // assert
            Assert.IsInstanceOfType(result, typeof(TransactionResult));
            Assert.IsFalse(result.HasErrors);
        }

        // valid order returns same items back
        [TestMethod]
        public void SubmitPayment_returns_TransactionResult_with_same_items_for_valid_order()
        {
            // arrange
            var order = new Order();
            order.Items.Add(new Product { Id = "ABC", Name = "Widget 1", Description = "A widget", Price = 1.99m });
            order.Items.Add(new Product { Id = "DEF", Name = "Widget 2", Description = "Another widget", Price = 3.99m });
            order.PaymentInfo = _paymentInfo;
            
            // act
            var result = _paymentService.SubmitPayment(order);

            // assert
            Assert.AreEqual(2, result.PurchasedItems.Count);
        }

        // invalid order returns transaction result with errors

        [TestMethod]
        public void SubmitPayment_returns_TransactionResult_with_errors_for_invalid_credit_card()
        {
            // arrange
            var order = new Order();
            order.Items.Add(new Product { Id = "ABC", Name = "Widget 1", Description = "A widget", Price = 1.99m });
            order.PaymentInfo = _paymentInfo;
            // invalid CC #
            order.PaymentInfo.CreditCard.CardNumber = string.Empty;
            
            // act
            var result = _paymentService.SubmitPayment(order);

            // assert
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual("Invalid or missing credit card number.", result.Errors.First());
        }

        [TestMethod]
        public void SubmitPayment_returns_TransactionResult_with_errors_for_incomplet_credit_card()
        {
            // arrange
            var order = new Order();
            order.Items.Add(new Product { Id = "ABC", Name = "Widget 1", Description = "A widget", Price = 1.99m });
            order.PaymentInfo = _paymentInfo;
            // invalid CC #
            order.PaymentInfo.CreditCard.CVV = string.Empty;
            order.PaymentInfo.Address.Name = string.Empty;

            // act
            var result = _paymentService.SubmitPayment(order);

            // assert
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual(2, result.Errors.Count);
        }

        [TestMethod]
        public void SubmitPayment_returns_TransactionResult_with_errors_when_missing_items()
        {
            // arrange
            var order = new Order();
            order.PaymentInfo = _paymentInfo;

            // act
            var result = _paymentService.SubmitPayment(order);

            // assert
            Assert.AreEqual("Invalid order: item count must be greater than zero.", result.Errors.First());
        }
    }
}
