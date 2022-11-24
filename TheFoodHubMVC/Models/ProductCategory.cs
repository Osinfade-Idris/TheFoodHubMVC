using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TheFoodHubMVC.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
