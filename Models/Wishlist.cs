namespace OnlineGroceryStore.Models
{
    public class Wishlist
    {
        public int WishlistID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CustomerID { get; set; } // Ensure the correct type
    }
}
