namespace OnlineGroceryStore.Models
{
    public class RecentlyViewedItem
    {
        public int RecentlyViewedItemID { get; set; }
        public string ProductName { get; set; }
        public DateTime ViewedDate { get; set; }
        public int CustomerID { get; set; } // Ensure the correct type
    }
}
