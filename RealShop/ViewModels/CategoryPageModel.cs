using RealShop.Models;

namespace RealShop.ViewModels
{
#nullable disable
    public class CategoryPageModel
    {
        public Category TargetCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool IsAdmin { get; set; }
    }
}
