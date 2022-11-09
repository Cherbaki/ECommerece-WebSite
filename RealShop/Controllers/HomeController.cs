using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealShop.Areas.Identity.Data;
using RealShop.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RealShop.ViewModels;

namespace RealShop.Controllers
{
    public class HomeController : Controller
    {

        public readonly UserManager<User> _userManager;
        public readonly AppDbContext _dbContext;
        public readonly IWebHostEnvironment _webHostEnvironmant;

        public HomeController(AppDbContext dbContext,UserManager<User> userManager,IWebHostEnvironment webHostEnvironmant)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _webHostEnvironmant = webHostEnvironmant;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var rand = new Random();

            //Converting Table of IQueryable<indexPageEntity> into IQueryable<indexPageModel> 
            var IPMs = _dbContext.IndexPage.ToModel();
            //Evaluating target IndexPageModel based on id 1
            var IPM = IPMs.FirstOrDefault(ipm => ipm.EntityId == 3);

            if (IPM == null)
                return View();

            var TempProductsList = _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.User)
                .ToList();

            IPM.Products = TempProductsList.OrderBy(pr => rand.Next()).ToList();
            var TempCategoriesList = _dbContext.Categories.Include(cat => cat.MainIcon).ToList();
            IPM.Categories = TempCategoriesList.OrderBy(pr => rand.Next()).ToList();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                IPM.IsLoggedIn = false;
                return View(IPM);
            }
            IPM.IsLoggedIn = true;
            var curretnUsersRoles = await _userManager.GetRolesAsync(currentUser);

            if (curretnUsersRoles.Count() <= 0)
                IPM.IsAdmin = false;
            else if(curretnUsersRoles?.ElementAt(0) == "Admin")
                IPM.IsAdmin = true;
            else
                IPM.IsAdmin = false;

            return View(IPM);
        }
        [HttpGet]
        public IActionResult EditIndexPage() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIndexPage(IndexPageEntity ipe)
        {
            //Firstly Delete Images Form WWWRootFolder
            var IPE = await _dbContext.IndexPage
                .Include(ip => ip.TopImage)
                .Include(ip => ip.SpecificImage)
                .FirstOrDefaultAsync(ip => ip.Id == 3);

            if (IPE == null)
                return NotFound();

            DeleteImageFormWWWRoot(IPE.TopImage);
            DeleteImageFormWWWRoot(IPE.SpecificImage);

            IFormFile TempTopImageFile = ipe.TopImage.ImageFile;
            IFormFile TempSpecImageFile = ipe.SpecificImage.ImageFile;

            ipe.TopImage = new Image()
            {
                Name = TempTopImageFile.FileName,
                ImageUrl = GetImageUrl("Images/", TempTopImageFile),
                UserId = null,
                ProductId = null,
                CategoryId = null,
                IndexPageEntityIdForTopImage = 3,
                IndexPageEntityIdForSpecImage = null
            };
            ipe.SpecificImage = new Image()
            {
                Name = TempSpecImageFile.FileName,
                ImageUrl = GetImageUrl("Images/", TempSpecImageFile),
                UserId = null,
                ProductId = null,
                CategoryId = null,
                IndexPageEntityIdForTopImage = null,
                IndexPageEntityIdForSpecImage = 3
            };

            //To fix bug which does't updates existing TopBarImage in ImagesTable and creates next one
            //(This Id will be used at the end to delete image it is serving for)
            int? tempTopBarImageId = null;
            
            if(_dbContext.IndexPage!.Count() <= 0)
            {
                //Create New IndexPageEntity Row
                await _dbContext.IndexPage.AddAsync(ipe);
            }
            else
            {
                //Update Existing IndexPageEntity Row

                var dbIpe = await _dbContext.IndexPage
                    .Include(ip => ip.TopImage)
                    .Include(ip => ip.SpecificImage)
                    .FirstOrDefaultAsync(ip => ip.Id == 3);

                if (dbIpe == null)
                    return NotFound();

                tempTopBarImageId = dbIpe.TopImage.Id;

                dbIpe.SpecificImage = ipe.SpecificImage;
                dbIpe.TopImage = ipe.TopImage;

                dbIpe.TopImageId = ipe.TopImageId;
                dbIpe.SpecificImageId = ipe.SpecificImageId;

                _dbContext.IndexPage.Update(dbIpe);
            }

            await _dbContext.SaveChangesAsync();

            //Deleting not updated TopBarImage
            var TargetTopBarImage = await _dbContext.Image.FindAsync(tempTopBarImageId);
            if (TargetTopBarImage != null) { 
                _dbContext.Image.Remove(TargetTopBarImage);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateCategory() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryModel catModel)
        {
            if (catModel == null)
                return NotFound();

            if(_dbContext.Categories.FirstOrDefault(ct => ct.Name == catModel.Name) != null)
                ModelState.AddModelError("name", "This name is already taken");

            if (!ModelState.IsValid)
                return View(catModel);


            var category = new Category
            {
                Name = catModel.Name
            };
            
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            var targetCategory = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.Name == category.Name);

            if (targetCategory == null)
                return NotFound();

            var mainIcon = new Image
            {
                Name = catModel.MainIconFile!.FileName,
                ImageUrl = GetImageUrl("Images/", catModel.MainIconFile),
                UserId = null,
                ProductId = null,
                CategoryId = targetCategory.Id,
                IndexPageEntityIdForTopImage = null,
                IndexPageEntityIdForSpecImage = null
            };

            targetCategory.MainIcon = mainIcon;

            _dbContext.Categories.Update(targetCategory);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int? id)
        {

            if (id == null)
                return NotFound();
            var TargetCategory = await _dbContext.Categories
                .Include(ct => ct.MainIcon)
                .FirstOrDefaultAsync(ct => ct.Id == id);
            if (TargetCategory == null)
                return NotFound();

            var curCategoryProducts = (await _dbContext.Products.ToListAsync())
                .Where(pr => pr.Id == TargetCategory.Id);

            //Delete all the associated products
            foreach(var pr in curCategoryProducts)
            {
                await DeleteProduct(pr.Id);
            }

            //First Delete Associated Image
            var TargetImage = await _dbContext.Image.FindAsync(TargetCategory.MainIcon?.Id);
            if(TargetImage != null)
            {
                DeleteImageFormWWWRoot(TargetImage);
                _dbContext.Image.Remove(TargetImage);
                await _dbContext.SaveChangesAsync();
            }

            _dbContext.Categories.Remove(TargetCategory);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task DeleteProduct(int? id)
        {
            if (id == null)
                return;

            var TargetProduct = await _dbContext.Products
                .Include(pr => pr.MainIcon)
                .Include(pr => pr.Images)
                .FirstOrDefaultAsync(pr => pr.Id == id);

            if (TargetProduct == null)
                return;

            //Remove MainIcon from wwwrootfolder
            DeleteImageFormWWWRoot(TargetProduct.MainIcon!);
            //Frst Delete the main Icon to be able to delete product itself
            _dbContext.Image.Remove(TargetProduct.MainIcon!);
            await _dbContext.SaveChangesAsync();

            //Now remove all the product related images from the wwwrootfolder
            foreach (var img in TargetProduct.Images!)
            {
                DeleteImageFormWWWRoot(img);
            }

            //Now delete the product 
            _dbContext.Products.Remove(TargetProduct);
            await _dbContext.SaveChangesAsync();
        }

        //Delete user rule
        //public IActionResult DeleteUser()
        //{
        //    string id = "f11f2cdc-a384-46ba-a1c8-3a355a16d368";

        //    var TargetUserProfPic = _dbContext.Image.FirstOrDefault(im => im.UserId == id);

        //    if(TargetUserProfPic != null)
        //    {
        //        _dbContext.Image.Remove(TargetUserProfPic);
        //        _dbContext.SaveChanges();
        //    }

        //    var TargetUser = _dbContext.Users.Find(id);

        //    if(TargetUser == null)
        //        return RedirectToAction("Index");

        //    _dbContext.Users.Remove(TargetUser);
        //    _dbContext.SaveChanges();

        //    return RedirectToAction("Index");
        //}


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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}