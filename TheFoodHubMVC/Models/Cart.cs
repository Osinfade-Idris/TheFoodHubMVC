using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFoodHubMVC.Models
{
    public class Cart
    {
        [Key]

        public Guid CartId { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string StaffId { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
    }
}
