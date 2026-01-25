using Microsoft.AspNetCore.Mvc;
using OOP_MY.Entities;
using OOP_MY.ProjeContext;

namespace OOP_MY.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context(); // Database context instance

        // Display all customers
        public IActionResult Index()
        {
            var values = context.Customers.ToList(); // Get all customers from database
            return View(values); // Pass customer list to view
        }

        // Display form for adding new customer (GET request)
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(); // Return empty form view
        }

        // Handle form submission for adding new customer (POST request)
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            context.Customers.Add(customer); // Add new customer to database context
            context.SaveChanges(); // Save changes to database
            return RedirectToAction("Index"); // Redirect to customer list
        }
    }
}