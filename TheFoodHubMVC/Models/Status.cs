using System.ComponentModel.DataAnnotations;

namespace TheFoodHubMVC.Models
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
