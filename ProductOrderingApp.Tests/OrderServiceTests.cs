using ProductOrderingApp.Services;
using Xunit;

namespace ProductOrderingApp.Tests
{
    public class OrderServiceTests
    {
        private readonly OrderService _orderService = new OrderService();

        [Fact]
        public void CalculateDiscount_ShouldReturn10Percent_WhenLoyalCustomerAndAmountIs100OrMore()
        {
            var discount = _orderService.CalculateDiscount(100, "Loyal");
            Assert.Equal(10, discount);
        }

        [Fact]
        public void CalculateDiscount_ShouldReturnZero_WhenNewCustomerEvenIfAmountIs100()
        {
            var discount = _orderService.CalculateDiscount(100, "New");
            Assert.Equal(0, discount);
        }

        [Fact]
        public void CalculateDiscount_ShouldReturnZero_WhenLoyalCustomerButAmountIsLessThan100()
        {
            var discount = _orderService.CalculateDiscount(99, "Loyal");
            Assert.Equal(0, discount);
        }
    }
}
