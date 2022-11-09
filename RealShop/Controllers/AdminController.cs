using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealShop.Areas.Identity.Data;
using RealShop.Models;
using Microsoft.EntityFrameworkCore;

namespace RealShop.Controllers
{
    public class AdminController : Controller
    {
        public readonly UserManager<User> _userManager;
        public readonly AppDbContext _dbContext;
        public readonly IWebHostEnvironment _webHostEnvironmant;

        public AdminController(AppDbContext dbContext, UserManager<User> userManager, IWebHostEnvironment webHostEnvironmant)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _webHostEnvironmant = webHostEnvironmant;
        }
        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
                return NotFound();

            var currentUserRoles = await _userManager.GetRolesAsync(currentUser);

            if (currentUserRoles.Count() <= 0)
                return NotFound();
            else if (currentUserRoles.ElementAt(0) == "Admin")
                return View();

            return NotFound();
        }

        public async Task<IActionResult> Orders()
        {

            var orders = await _dbContext.Orders
                .Include(or => or.Product)
                .Include(or => or.User)
                .ToListAsync();

            if (orders == null)
                return NotFound();

            return View(orders);
        }

        public async Task<IActionResult> DelteOrder(int? id) 
        {
            if (id == null)
                return NotFound();
            var targetOrder = await _dbContext.Orders.FindAsync(id);

            if (targetOrder == null)
                return NotFound();

            _dbContext.Orders.Remove(targetOrder);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Orders");
        }
    }
}
