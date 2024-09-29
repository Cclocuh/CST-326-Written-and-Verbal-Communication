using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Data;
using OnlineGroceryStore.Models;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    [Authorize] // Ensure the user is logged in to access these actions
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GroceryStoreContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, GroceryStoreContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get current logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Return the user account details view
            return View(user);  // This will look for Index.cshtml by default
        }


        public IActionResult OrderHistory()
        {
            // Fetch order history based on the current user
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int customerId)) // Convert string userId to integer
            {
                var orders = _context.Orders.Where(o => o.CustomerID == customerId).ToList();
                return View(orders);
            }

            return NotFound(); // If userId is not a valid integer
        }

        public IActionResult MyOrders()
        {
            // Show active and pending orders
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int customerId)) // Convert string userId to integer
            {
                var orders = _context.Orders.Where(o => o.CustomerID == customerId && o.Status != "Completed").ToList();
                return View(orders);
            }

            return NotFound(); // If userId is not a valid integer
        }


        public IActionResult Wishlist()
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int customerId)) // Convert string userId to integer
            {
                var wishlistItems = _context.Wishlist.Where(w => w.CustomerID == customerId).ToList();
                return View(wishlistItems);
            }

            return NotFound(); // If userId is not a valid integer
        }

        public IActionResult Payments()
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int customerId)) // Convert string userId to integer
            {
                var payments = _context.Payments.Where(p => p.CustomerID == customerId).ToList();
                return View(payments);
            }

            return NotFound(); // If userId is not a valid integer
        }

        public IActionResult RecentlyViewed()
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int customerId)) // Convert string userId to integer
            {
                var recentItems = _context.RecentlyViewedItems.Where(rv => rv.CustomerID == customerId).ToList();
                return View(recentItems);
            }

            return NotFound(); // If userId is not a valid integer
        }

    }
}

