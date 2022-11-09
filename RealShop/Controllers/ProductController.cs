using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealShop.Areas.Identity.Data;
using RealShop.Models;
using RealShop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace RealShop.Controllers
{
    public class ProductController : Controller
    {

        public readonly UserManager<User> _userManager;
        public readonly AppDbContext _dbContext;
        public readonly IWebHostEnvironment _webHostEnvironmant;


        public ProductController(AppDbContext dbContext, UserManager<User> userManager, IWebHostEnvironment webHostEnvironmant)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _webHostEnvironmant = webHostEnvironmant;
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var CPPM = new CreateProductPageModel();

            var Categories = _dbContext.Categories.Include(ct => ct.MainIcon);

            ViewBag.CategoryNames = new List<string>();
            foreach(var category in Categories)
            {
                ViewBag.CategoryNames.Add(category.Name);
            }

            return View(CPPM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductPageModel cppm)
        {

            var user = await _userManager.GetUserAsync(User);

            if (cppm == null)
                return NotFound();

            var TargetCategory = await _dbContext.Categories
                .FirstOrDefaultAsync(ct => ct.Name == cppm.TargetCategoryName);
            if (TargetCategory == null)
                return NotFound();

            if (cppm.MainIconFile == null || cppm.ProductImagesFiles == null)
            {
                var Categories = _dbContext.Categories.Include(ct => ct.MainIcon);

                ViewBag.CategoryNames = new List<string>();
                foreach (var category in Categories)
                {
                    ViewBag.CategoryNames.Add(category.Name);
                }

                return View(cppm);
            }

            var MainIcon = new Image
            {
                Name = cppm.MainIconFile.FileName,
                ImageUrl = GetImageUrl("Images/Products/", cppm.MainIconFile),
                UserId = null,
                ProductId = null,//Product Id will be assinged automatically
                CategoryId = null,
                IndexPageEntityIdForTopImage = null,
                IndexPageEntityIdForSpecImage = null,
            };

            var productImages = new List<Image>();

            foreach(var imageFile in cppm.ProductImagesFiles)
            {
                var NewImage = new Image
                {
                    Name = imageFile.FileName,
                    ImageUrl = GetImageUrl("Images/Products/", imageFile),
                    UserId = null,
                    ProductId = null,//Product Id will be assinged automatically
                    CategoryId = null,
                    IndexPageEntityIdForTopImage = null,
                    IndexPageEntityIdForSpecImage = null
                };

                productImages.Add(NewImage);
            }

            var newProduct = new Product
            {
                Name = cppm.Name,
                Description = cppm.Description,
                Price = cppm.Price,
                MainIcon = MainIcon,
                Images = productImages,
                Orders = null,
                CategoryId = TargetCategory.Id,
                Category = TargetCategory,
                UserId = user.Id,
            };

            _dbContext.Products.Add(newProduct);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
                return NotFound();

            var TargetProduct = await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.Images)
                .FirstOrDefaultAsync(pr => pr.Id == id);

            if (TargetProduct == null)
                return NotFound();

            //Remove MainIcon from wwwrootfolder
            DeleteImageFormWWWRoot(TargetProduct.MainIcon!);
            //Frst Delete the main Icon to be able to delete product itself
            _dbContext.Image.Remove(TargetProduct.MainIcon!);
            await _dbContext.SaveChangesAsync();
            
            //Now remove all the product related images from the wwwrootfolder
            foreach(var img in TargetProduct.Images!)
            {
                DeleteImageFormWWWRoot(img);
            }

            //Now delete the product 
            _dbContext.Products.Remove(TargetProduct);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> ProductPage(int? productId)
        {
            if (productId == null)
                return NotFound();

            var targetProduct = await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.Images)
                .FirstOrDefaultAsync(pr => pr.Id == productId);

            if (targetProduct == null)
                return NotFound();

            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = false;
            bool isProductOwner = false;
            bool isSignedIn = false;
            if (currentUser != null)
            {
                isSignedIn = true;
                var currentUsersRoles = await _userManager.GetRolesAsync(currentUser);
                isAdmin = false;
                isProductOwner = false;

                if (currentUsersRoles.Count() <= 0)
                    isAdmin = false;
                else if (currentUsersRoles?.ElementAt(0) == "Admin")
                    isAdmin = true;

                if (targetProduct.UserId == currentUser.Id)
                    isProductOwner = true;
                else
                    isProductOwner = false;
            }

            var PPM = new ProductPageModel
            {
                TargetProduct = targetProduct,
                Categories = _dbContext.Categories.Include(ct => ct.MainIcon),
                IsAdmin = isAdmin,
                IsProductOwner = isProductOwner,
                IsSignedIn = isSignedIn
            };


            return View(PPM);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
                return NotFound();

            var TargetProduct = await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.Images)
                .FirstOrDefaultAsync(pr => pr.Id == id);
            if (TargetProduct == null)
                return NotFound();

            var eppm = new EditProductPageModel
            {
                Name = TargetProduct.Name,
                Description = TargetProduct.Description,
                Price = TargetProduct.Price,
                productId = TargetProduct.Id
            };

            var Categories = _dbContext.Categories.Include(ct => ct.MainIcon);

            ViewBag.CategoryNames = new List<string>();
            foreach (var category in Categories)
            {
                ViewBag.CategoryNames.Add(category.Name);
            }


            return View(eppm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductPageModel eppm,int productid)
        {
            eppm.productId = productid;
            if (!ModelState.IsValid)
                return View(eppm);

            var targetProduct = await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.Images)
                .FirstOrDefaultAsync(pr => pr.Id == eppm.productId);
            
            if (targetProduct == null)
                return NotFound();

            targetProduct.Name = eppm.Name;
            targetProduct.Description = eppm.Description;
            targetProduct.Price = eppm.Price;

            var targetCategory = await _dbContext.Categories.FirstOrDefaultAsync(ct => ct.Name == eppm.TargetCategoryName);
            if (targetCategory == null)
                return NotFound();

            targetProduct.CategoryId = targetCategory.Id;
            targetProduct.Category = targetCategory;

            //Delete All product Related Images from WWWRootFolder
            //Remove MainIcon from wwwrootfolder
            DeleteImageFormWWWRoot(targetProduct.MainIcon!);
            //Frst Delete the main Icon to be able to delete product itself
            _dbContext.Image.Remove(targetProduct.MainIcon!);
            await _dbContext.SaveChangesAsync();

            //Now remove all the product related images from the wwwrootfolder, as well as from database
            foreach (var img in targetProduct.Images!)
            {
                DeleteImageFormWWWRoot(img);
                var targImage = await _dbContext.Image.FindAsync(img.Id);
                if (targImage == null)
                    return NotFound();
                _dbContext.Image.Remove(targImage);
            }
            await _dbContext.SaveChangesAsync();

            //Now lets create Images for Mainicon and related pictures
            var MainIcon = new Image
            {
                Name = eppm.MainIconFile.FileName,
                ImageUrl = GetImageUrl("Images/Products/", eppm.MainIconFile),
                UserId = null,
                ProductId = targetProduct.Id,
                CategoryId = null,
                IndexPageEntityIdForTopImage = null,
                IndexPageEntityIdForSpecImage = null,
            };

            var productImages = new List<Image>();

            foreach (var imageFile in eppm.ProductImagesFiles)
            {
                var NewImage = new Image
                {
                    Name = imageFile.FileName,
                    ImageUrl = GetImageUrl("Images/Products/", imageFile),
                    UserId = null,
                    ProductId = targetProduct.Id,
                    CategoryId = null,
                    IndexPageEntityIdForTopImage = null,
                    IndexPageEntityIdForSpecImage = null
                };

                productImages.Add(NewImage);
            }

            targetProduct.MainIcon = MainIcon;
            targetProduct.Images = productImages;

            _dbContext.Products.Update(targetProduct);
            await _dbContext.SaveChangesAsync();


            return RedirectToAction("Index", "Profile");
        }
        
        public async Task<IActionResult> CreateOrder(int? productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
                return NotFound();

            var newOrder = new Order
            {
                Name = Guid.NewGuid().ToString() + user.FirstName + product.Name,
                MoneySpent = product.Price,
                ProductName = product.Name!,
                Product = product,
                ProductId = productId,
                UserName = user.FirstName!,
                User = user,
                UserId = user.Id
            };

            await _dbContext.Orders.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();
            

            return RedirectToAction("OrderSuccess", new { orderId = newOrder.Id});
        }

        public async Task<IActionResult> OrderSuccess(int? orderId)
        {
            if (orderId == null)
                return NotFound();

            var TargetOrder = await _dbContext.Orders.FindAsync(orderId);

            if (TargetOrder == null)
                return NotFound();

            return View(TargetOrder);
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
