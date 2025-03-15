// using Microsoft.AspNetCore.Mvc;
// using ProductOrderingApp.Models;
// using System.Collections.Generic;
// using System.Linq;

// public class OrderController : Controller
// {
//     // In-memory list of products
//     private List<Product> _products = new List<Product>
//     {
//         new Product { Id = 1, Name = "Product 1", Price = 30 },
//         new Product { Id = 2, Name = "Product 2", Price = 50 },
//         new Product { Id = 3, Name = "Product 3", Price = 70 }
//     };

// // If you want to use a view with a name different from the action name, you need to specify it explicitly. In this case, even though the action
// // is PlaceOrder, the controller is returning a view named OrderResult
// //  (which could be located in the Views/Order/OrderResult.cshtml).
// [HttpPost]
// public IActionResult PlaceOrder(List<OrderItem> orderItems, string customerType)
// {
//     // Load the products from the in-memory list to populate the OrderItems' Product property
//     foreach (var item in orderItems)
//     {
//         item.Product = _products.FirstOrDefault(p => p.Id == item.ProductId); // Retrieve product by ProductId
//     }

//     var order = new Order
//     {
//         Items = orderItems,
//         CustomerType = customerType
//     };

//     // Calculate the total order amount
//     order.TotalAmount = orderItems.Sum(item => item.Product?.Price * item.Quantity ?? 0); // Handle null Product gracefully

//     // Apply discount only if the customer is "Loyal" and total amount >= 100
//     if (customerType == "Loyal" && order.TotalAmount >= 100)
//     {
//         order.Discount = 0.1m * order.TotalAmount; // 10% discount for loyal customers with orders >= $100
//     }
//     else
//     {
//         order.Discount = 0; // No discount for new customers or orders less than $100
//     }

//     // Calculate final amount after discount
//     order.FinalAmount = order.TotalAmount - order.Discount;

//     // Pass the order object to the OrderResult view
//     return View("OrderResult", order);
// }



// }



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

