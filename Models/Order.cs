using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        // Foreign Key
        [Required]
        public int CustomerID { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        // New Status Property
        [Required]
        [StringLength(50)]  // Optional: You can limit the length of the status string
        public string Status { get; set; } // Could be "Pending", "Shipped", "Completed", etc.
    }
}

