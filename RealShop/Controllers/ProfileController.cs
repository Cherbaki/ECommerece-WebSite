using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealShop.Areas.Identity.Data;
using RealShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using RealShop.Models;

namespace RealShop.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironmant;
        public ProfileController(AppDbContext dbContext,UserManager<User> userManger,IWebHostEnvironment webHostEnvironmant)
        {
            _dbContext = dbContext;
            _userManager = userManger;
            _webHostEnvironmant = webHostEnvironmant;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Getting data of current user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return NotFound();

            var user = await _dbContext.Users
                .Include(us => us.ProfileImage)
                .Include(us => us.Orders)
                .FirstOrDefaultAsync(us => us.Id == currentUser.Id);

            if (user == null)
                return NotFound();

            var products = (await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .ToListAsync())
                .Where(pr => pr.UserId == user.Id);



            //Getting All the categories
            var categories = _dbContext.Categories.Include(ct => ct.MainIcon).ToList();
            if (categories == null)
                return NotFound();

            var PPM = new ProfilePageModel
            {
                CurrentUser = user,
                Categories = categories,
                IsAdmin = false,
                Products = products
            };

            var curretnUsersRoles = await _userManager.GetRolesAsync(user);
            if (curretnUsersRoles.Count() <= 0)
                PPM.IsAdmin = false;
            else if (curretnUsersRoles?.ElementAt(0) == "Admin")
                PPM.IsAdmin = true;

            return View(PPM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProfilePageModel ppm)
        {
            if (ppm == null || ppm.CurrentUser == null || ppm.CurrentUser.ProfileImage == null 
                || ppm.CurrentUser.ProfileImage.ImageFile == null)
                return NotFound();

            
            var currentUserId = (await _userManager.GetUserAsync(User)).Id;

            var currentUser = await _dbContext.Users.Include(us => us.ProfileImage).FirstOrDefaultAsync(us =>  us.Id == currentUserId);
            if (currentUser is null || currentUser.ProfileImage is null)
                return NotFound();

            //Delete existing profile picture form wwwroot
            DeleteImageFormWWWRoot(currentUser.ProfileImage);


            //Changing name and url of the image
            currentUser.ProfileImage!.Name = ppm.CurrentUser.ProfileImage.ImageFile.FileName;
            currentUser.ProfileImage!.ImageUrl = GetImageUrl("Images/", ppm.CurrentUser.ProfileImage.ImageFile);

            _dbContext.Users.Update(currentUser);
            await _dbContext.SaveChangesAsync();



            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Orders()
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;

            if (userId == null)
                return NotFound();

            var currentUserOrders = _dbContext.Orders
                .Include(or => or.User)
                .Include(or => or.Product)
                .ToList()
                .Where(or => or.UserId == userId);

            foreach (var order in currentUserOrders)
            {
                order.Product = await _dbContext.Products
                    .Include(pr => pr.MainIcon)
                    .FirstOrDefaultAsync(pr => pr.Id == order.Product!.Id);
            }

            return View(currentUserOrders);
        }

        public bool DeleteImageFormWWWRoot(Image image)
        {
            string path = image.ImageUrl.Remove(0, 1);
            path = Path.Combine(_webHostEnvironmant.WebRootPath, path);


            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }

            return false;
        }
        public string GetImageUrl(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + file.FileName;
            string serverPath = Path.Combine(_webHostEnvironmant.WebRootPath, folderPath);

            var newFile = new FileStream(serverPath, FileMode.Create);

            file.CopyTo(newFile);

            newFile.Close();

            return "/" + folderPath;
        }

    }
}
