using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OOP_MY.Entities;
using OOP_MY.ProjeContext;
using OOP_MY.Validators.ProductValidator;

namespace OOP_MY.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context(); // Database context for product operations

        // Display all products
        public IActionResult Index()
        {
            var values = context.Products.ToList(); // Get all products from database
            return View(values); // Pass product list to view
        }

        // Display form for adding new product (GET request)
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(); // Return empty form view
        }

        // Handle form submission for adding new product (POST request)
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ProductValidator validationRules = new ProductValidator(); // Create validator instance

            ValidationResult results = validationRules.Validate(product); // Validate product data

            if (results.IsValid) // Check if validation passed
            {
                // Note: Missing implementation for valid case
                // Should add product only if validation passes
            }

            // Currently adds product even if validation fails
            context.Products.Add(product); // Add product to database context
            context.SaveChanges(); // Save changes to database
            return RedirectToAction("Index"); // Redirect to product list
        }

        // Delete product by ID
        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id); // Find product by ID (alternative: Where(x=>x.Id == id))
            context.Products.Remove(value); // Remove product from context
            context.SaveChanges(); // Save changes to database
            return RedirectToAction("Index"); // Redirect to product list
        }

        // Display form for updating product (GET request)
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x => x.Id == id).FirstOrDefault(); // Find product by ID
            return View(value); // Pass product to view for editing
        }

        // Handle form submission for updating product (POST request)
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            // Commented out manual update approach (updates individual properties)
            //var value = context.Products.Where(p => p.Id == product.Id).FirstOrDefault();

            //value.Name = product.Name;
            //value.Price = product.Price;
            //value.Stock = product.Stock;

            //context.Products.Update(value);
            //context.SaveChanges();
            //return RedirectToAction("Index");

            // Current approach: Update entire product object
            context.Products.Update(product); // Mark product as modified
            context.SaveChanges(); // Save changes to database
            return RedirectToAction("Index"); // Redirect to product list
        }
    }
}