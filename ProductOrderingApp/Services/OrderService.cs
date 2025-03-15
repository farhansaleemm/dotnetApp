namespace ProductOrderingApp.Services
{
    public class OrderService
    {
        public decimal CalculateDiscount(decimal totalAmount, string customerType)
        {
            if (customerType == "Loyal" && totalAmount >= 100)
            {
                return totalAmount * 0.10m; // 10% discount
            }
            return 0; // No discount
        }
    }
}
