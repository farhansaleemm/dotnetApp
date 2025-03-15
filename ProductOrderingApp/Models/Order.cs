public class Order
{
   public List<OrderItem> Items { get; set; } = new();
    public string CustomerType { get; set; } =string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalAmount { get; set; }
}
