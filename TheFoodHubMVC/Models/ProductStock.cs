using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFoodHubMVC.Models
{
    public class ProductStock
    {
        [Key]
        public Guid ProductStockId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string StaffId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
