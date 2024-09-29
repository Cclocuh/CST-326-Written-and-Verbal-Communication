using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }  // Example: "Fruits", "Vegetables"

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        // Navigation properties
        //public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
