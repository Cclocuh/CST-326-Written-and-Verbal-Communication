using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineGroceryStore.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Foreign Key for the Customer, allowing up to 450 characters (to match typical ASP.NET Identity user ID)
        [Required]
        [StringLength(450)]  // Adjust to match the length of your IdentityUser Id (450 is typical for GUID)
        public string CustomerID { get; set; }

        // Foreign Key for the Product
        [Required]
        public int ProductID { get; set; }

        // Navigation properties
        [ForeignKey("CustomerID")]
        public ApplicationUser Customer { get; set; }  // Use ApplicationUser instead of Customer

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get { return Quantity * Product.Price; }
        }
    }
}




