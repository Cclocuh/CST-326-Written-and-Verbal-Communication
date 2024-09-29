using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Data;
using OnlineGroceryStore.Models;

namespace OnlineGroceryStore.Controllers
{
    //[Authorize(Roles = "Admins")]  // Ensures only Admin users can access these actions
    public class AdminsController : Controller
    {
        private readonly GroceryStoreContext _context;

        public AdminsController(GroceryStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Products));
        }

        // GET: Admin/Products with Search functionality
        public async Task<IActionResult> Products(string searchString)
        {
            // Save the current search filter to ViewData to preserve the search query
            ViewData["CurrentFilter"] = searchString;

            // Retrieve all products
            var products = from p in _context.Products
                           select p;

            // If search string is not null or empty, filter the products
            if (!String.IsNullOrEmpty(searchString))
            {
                // Searching in ProductName and Category
                products = products.Where(p => p.ProductName.Contains(searchString) || p.Category.Contains(searchString));
            }

            // Return the filtered product list to the view
            return View(await products.ToListAsync());
        }

        // GET: Admin/CreateProduct
        public IActionResult CreateProduct()
        {
            return View();
        }

        // POST: Admin/CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        // GET: Admin/EditProduct/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/EditProduct/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        // GET: Admin/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/DeleteProduct/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Products)); // Redirect to product listing
        }
    }
}

