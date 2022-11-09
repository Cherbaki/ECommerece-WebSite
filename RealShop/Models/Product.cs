using RealShop.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealShop.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Name of the product can't be longer than 25 character")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description of the product can't be longer than 500 character")]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required]
        [NotMapped]
        public Image? MainIcon { get; set; }
        [NotMapped]
        public ICollection<Image>? Images { get; set; }
        [NotMapped]
        public ICollection<Order>? Orders { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        public int? CategoryId { get; set; }
        [Required]
        public Category? Category { get; set; }
    }
}
