public class Order
{
    public List<OrderItem> Items { get; set; }
    public string CustomerType { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalAmount { get; set; }
}
