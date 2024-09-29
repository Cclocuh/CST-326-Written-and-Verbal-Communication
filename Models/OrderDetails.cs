using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Foreign Keys
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
