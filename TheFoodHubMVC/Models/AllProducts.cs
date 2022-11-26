using System.ComponentModel.DataAnnotations;

namespace TheFoodHubMVC.Models
{
    public class AllProducts
    {
        [Key]
        public Guid ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string StatusId { get; set; }
        public string ProductPicture { get; set; }
    }
}
