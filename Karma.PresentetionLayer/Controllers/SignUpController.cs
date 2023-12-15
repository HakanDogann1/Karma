using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Extensions;
using Karma.PresentetionLayer.Models.AppUserViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SignUpController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignUpViewModel signUpViewModel)
        {
            var user = new AppUser() { Email = signUpViewModel.Email, UserName = signUpViewModel.UserName, Name = signUpViewModel.Name, Surname = signUpViewModel.Surname, PhoneNumber = signUpViewModel.PhoneNumber };
            var result = await _userManager.CreateAsync(user, signUpViewModel.PasswordConfirm);
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
                return View();
            }
            return View();
        }
    }
}
