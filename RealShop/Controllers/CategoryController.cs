using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealShop.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using RealShop.ViewModels;

namespace RealShop.Controllers
{
    public class CategoryController : Controller
    {
        public readonly UserManager<User> _userManager;
        public readonly AppDbContext _dbContext;
        public readonly IWebHostEnvironment _webHostEnvironmant;

        public CategoryController(AppDbContext dbContext, UserManager<User> userManager, IWebHostEnvironment webHostEnvironmant)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _webHostEnvironmant = webHostEnvironmant;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if (categoryId == null)
                return NotFound();

            var targetCategory = await _dbContext.Categories
                .Include(ct => ct.MainIcon)
                .FirstOrDefaultAsync(ct => ct.Id == categoryId);
            if (targetCategory == null)
                return NotFound();

            var targetCategoryProducts =  (await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.User)
                .ToListAsync())
                .Where(pr => pr.CategoryId == targetCategory.Id);

            var cpm = new CategoryPageModel
            {
                TargetCategory = targetCategory,
                Categories = _dbContext.Categories.Include(ct => ct.MainIcon).ToList(),
                Products = targetCategoryProducts,
                IsAdmin = false
            };

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return View(cpm);
            var curretnUsersRoles = await _userManager.GetRolesAsync(currentUser);

            if (curretnUsersRoles.Count() <= 0)
                cpm.IsAdmin = false;
            else if (curretnUsersRoles?.ElementAt(0) == "Admin")
                cpm.IsAdmin = true;


            return View(cpm);
        }
    }
}
