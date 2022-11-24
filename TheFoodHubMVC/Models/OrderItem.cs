using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFoodHubMVC.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int OrderItemId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
