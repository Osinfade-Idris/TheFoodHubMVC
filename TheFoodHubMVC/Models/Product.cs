using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFoodHubMVC.Models
{
    public class Product
    {
        [Key]
        [Required]
        public Guid ProductId { get; set; }

        public ProductCategory Category { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        [Required]
        public Status Status { get; set; }  
        [Required]
        public string ProductPicture { get; set; }
        public List<OrderItem> OrderItems { get; set; }


    }
}
