using Microsoft.AspNetCore.Mvc;
using ProductOrderingApp.Models;

public class HomeController : Controller
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 30 },
        new Product { Id = 2, Name = "Product 2", Price = 50 },
        new Product { Id = 3, Name = "Product 3", Price = 70 }
    };

    // This method is used to display the product selection form
    // If you don’t specify a view name explicitly, ASP.NET Core assumes you
    // want to use the view that matches the action name (Index in this case). 
    //So, it looks for a view file named Index.cshtml in the Views/Home/ folder (since the controller is HomeController)
    public IActionResult Index()
    {
        return View(_products);  // Passing the list of products to the view
    }
}
