using Microsoft.AspNetCore.Mvc;
using ProductOrderingApp.Models;
using ProductOrderingApp.Services;
using System.Collections.Generic;
using System.Linq;

public class OrderController : Controller
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 30 },
        new Product { Id = 2, Name = "Product 2", Price = 50 },
        new Product { Id = 3, Name = "Product 3", Price = 70 }
    };

    private readonly OrderService _orderService;

    public OrderController()
    {
        _orderService = new OrderService();
    }

    [HttpPost]
    public IActionResult PlaceOrder(List<OrderItem> orderItems, string customerType)
    {
        foreach (var item in orderItems)
        {
            item.Product = _products.FirstOrDefault(p => p.Id == item.ProductId);
        }

        var order = new Order
        {
            Items = orderItems,
            CustomerType = customerType
        };

        order.TotalAmount = orderItems.Sum(item => item.Product?.Price * item.Quantity ?? 0);

        // Use OrderService to calculate discount
        order.Discount = _orderService.CalculateDiscount(order.TotalAmount, customerType);

        order.FinalAmount = order.TotalAmount - order.Discount;

        return View("OrderResult", order);
    }
}

