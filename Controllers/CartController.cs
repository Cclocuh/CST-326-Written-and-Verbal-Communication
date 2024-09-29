using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Data;
using OnlineGroceryStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineGroceryStore.Controllers
{
    public class CartController : Controller
    {
        private readonly GroceryStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(GroceryStoreContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // Retrieve cart items for the current user and include the product details
            var cartItems = await _context.Carts
                .Where(c => c.CustomerID == user.Id)  // Filter by the current user's ID
                .Include(c => c.Product)  // Include related product information
                .ToListAsync();

            return View(cartItems);
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int cartId, int quantity)
        {
            // Retrieve the cart item based on its ID
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem == null)
                return NotFound();

            // If the quantity is greater than 0, update it; otherwise, remove the item
            if (quantity > 0)
            {
                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // POST: Cart/DeleteFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFromCart(int cartId)
        {
            // Find the cart item based on its ID
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index"); // Redirect back to the cart page
        }

        // GET: Cart/AddToCart/5
        public async Task<IActionResult> AddToCart(int id)
        {
            // Retrieve the product by its ID
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            ViewBag.Product = product;
            return View();  // Render the AddToCart view with product details
        }

        // POST: Cart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            // Check if the product is already in the cart
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductID == id && c.CustomerID == user.Id);
            if (cartItem != null)
            {
                // Update the quantity if it's already in the cart
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add a new cart item if it doesn't exist
                cartItem = new Cart
                {
                    ProductID = id,
                    Quantity = quantity,
                    CustomerID = user.Id  // Store the current user's ID
                };
                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}




