using RealShop.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RealShop.ViewModels
{
#nullable disable
    public class IndexPageModel
    {
        public int EntityId { get; set; }
        [Required]
        public Image TopImage { get; set; }
        [Required]
        public int TopImageId { get; set; }
        [Required]
        public Image SpecificImage { get; set; }
        [Required]
        public int SpecificImageId { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsLoggedIn { get; set; } = false;
    }
}