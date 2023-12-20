using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Extensions;
using Karma.PresentetionLayer.Models.AppUserViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = new AppUser() { Email = signUpViewModel.Email, UserName = signUpViewModel.UserName, Name = signUpViewModel.Name, Surname = signUpViewModel.Surname, PhoneNumber = signUpViewModel.PhoneNumber };
           
            var result = await _userManager.CreateAsync(user, signUpViewModel.PasswordConfirm);
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors.ToList());
                return View();
            }
            var claim = new Claim("ExchangeExpireDateTime", DateTime.Now.AddDays(15).ToShortDateString());
            var currentUser = await _userManager.FindByNameAsync(user.UserName);
            var claimResult = await _userManager.AddClaimAsync(currentUser, claim);
            if (!claimResult.Succeeded)
            {
                ModelState.AddModelErrorList(claimResult.Errors.ToList());
                return View();
            }
            ViewBag.success = "Kayıt başarılı";
			return View();
        }
    }
}
