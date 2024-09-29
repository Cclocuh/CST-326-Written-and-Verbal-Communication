namespace OnlineGroceryStore.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }
        public string CardType { get; set; }
        public string Last4Digits { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CustomerID { get; set; } // Ensure the correct type
    }
}
