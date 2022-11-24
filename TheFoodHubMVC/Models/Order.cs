using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFoodHubMVC.Models
{
    public class Order
    {
        [Key]
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string StaffId { get; set; }
        [Required]
        public decimal OrderTotal { get; set; }

        public Status Status { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

    }
}
