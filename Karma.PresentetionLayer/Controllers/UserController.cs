using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Extensions;
using Karma.PresentetionLayer.Models.AppUserViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Karma.PresentetionLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly SignInManager<AppUser> _signInManager;

		public UserController(UserManager<AppUser> userManager, IFileProvider fileProvider, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_fileProvider = fileProvider;
			_signInManager = signInManager;
		}

		public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<UserListViewModel>();
            foreach (var user in users)
            {
                userList.Add(
                new UserListViewModel()
                {
                    Id= user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    UserName = user.UserName
                });
            }

            return View(userList);
        }

        public async Task<IActionResult> UserEdit()
        {
            var userName = HttpContext.User.Identity!.Name;
            var user= await _userManager.FindByNameAsync(userName);
            var userEdit = new UserEditViewModel();
            userEdit.Surname=user.Surname;
            userEdit.PhoneNumber=user.PhoneNumber;
            userEdit.UserName = user.UserName;
            userEdit.Email=user.Email;
            userEdit.Name = user.Name;
            userEdit.City = user.City;
            string[] UserImageArray = user.Image.Split('\\');
            var path = "~";
            int z = 1;
            for(int i =0; i <=9; i++)
            {
                if (i >= 7)
                {
                    path = path + "/" + UserImageArray[i];
                }
                
                z++;
            }
		
		TempData["image"]=path;
            userEdit.Id = user.Id;
            return View(userEdit);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit([FromForm]UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            

			user.Surname = model.Surname;
			user.PhoneNumber = model.PhoneNumber;
			user.UserName = model.UserName;
			user.Email = model.Email;
			user.Name = model.Name;
			user.City = model.City;
			
            if(model.Image!=null && model.Image.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Image.FileName)}";
                var newImagePath = Path.Combine(wwwrootFolder.First(x=>x.Name=="usersimage").PhysicalPath, randomImageName);

                using var stream = new FileStream(newImagePath, FileMode.Create);

                await model.Image.CopyToAsync(stream);

                user.Image = newImagePath;
                TempData["image"] = newImagePath;

			}
			
            var update = await _userManager.UpdateAsync(user);
            if(!update.Succeeded)
            {
                ModelState.AddModelErrorList(update.Errors.ToList());
                return View();
            }
			var result = await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, isPersistent: false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Hata oluştu");
			}
			ViewBag.success = "Profil değişikliği kaydedildi.";
            return View(model);
		}


    }
}
