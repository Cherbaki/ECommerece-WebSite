using RealShop.Areas.Identity.Data;
using RealShop.Models;

namespace RealShop.ViewModels
{
#nullable disable
    public class ProfilePageModel
    {
        public User CurrentUser { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool IsAdmin { get; set; }
    }
}
