using System.ComponentModel.DataAnnotations;

namespace RealShop.ViewModels
{
    public class CategoryModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public IFormFile? MainIconFile { get; set; }
    }
}
