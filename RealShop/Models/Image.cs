using RealShop.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealShop.Models
{
#nullable disable
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        [Required]    
        [NotMapped]
        public IFormFile ImageFile { get; set; }

#nullable enable
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        //-------------------------
        [ForeignKey("ProductForMainIcon")]
        public int? ProductIdForMainIcon { get; set; }
        public Product? ProductForMainIcon { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        //-------------------------

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("IndexPageEntityForTopImage")]
        public int? IndexPageEntityIdForTopImage { get; set; }
        public IndexPageEntity? IndexPageEntityForTopImage { get; set; }

        [ForeignKey("IndexPageEntityForSpecImage")]
        public int? IndexPageEntityIdForSpecImage { get; set; }
        public IndexPageEntity? IndexPageEntityForSpecImage { get; set; }


    }
}
