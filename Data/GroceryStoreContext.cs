using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Models;

namespace OnlineGroceryStore.Data
{
    public class GroceryStoreContext : IdentityDbContext<ApplicationUser> // Use ApplicationUser instead of IdentityUser
    {
        public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<PaymentMethod> Payments { get; set; }
        public DbSet<RecentlyViewedItem> RecentlyViewedItems { get; set; }

        public DbSet<Admin> Admin { get; set; } = default!;
    }
}

