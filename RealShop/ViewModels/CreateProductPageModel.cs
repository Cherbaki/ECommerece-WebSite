using RealShop.Models;
using System.ComponentModel.DataAnnotations;

namespace RealShop.ViewModels
{
#nullable disable
    public class CreateProductPageModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(350, ErrorMessage = "Description of the product can't be longer than 350 character")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name="Main icon")]
        public IFormFile MainIconFile { get; set; }
        [Required]
        [Display(Name="Associated images")]
        public IFormFileCollection ProductImagesFiles { get; set; }
        [Required]
        [Display(Name = "Select the target category")]  
        public string TargetCategoryName { get; set; } 
    }
}
