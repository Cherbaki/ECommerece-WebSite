using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealShop.Models
{
    public class Category
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Image? MainIcon { get; set; }
        
        [NotMapped]
        public ICollection<Product>? Products { get; set; }
    }
}
