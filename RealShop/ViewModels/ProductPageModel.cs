
using RealShop.Models;

namespace RealShop.ViewModels
{
#nullable disable
    public class ProductPageModel
    {
        public Product TargetProduct { get; set; }
        public IEnumerable<Category > Categories { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsProductOwner { get; set; }
        public bool IsSignedIn { get; set; }
    }
}
