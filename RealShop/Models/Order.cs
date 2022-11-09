using RealShop.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal MoneySpent { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        [Required]
        public string? ProductName { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
