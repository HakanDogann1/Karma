using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Extensions;
using Karma.PresentetionLayer.Models.AppUserViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
	public class SignInController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		public SignInController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SignInViewModel request)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var user = await _userManager.FindByEmailAsync(request.Email);

			if(user == null)
			{
				ModelState.AddModelErrorList(new List<string>() { "Kullanıcı bulunamadı. Hesap oluşturmak için kayıt ol sayfasına gidebilirsiniz." });
			}

			var response = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!response.Succeeded)
            {
				ModelState.AddModelError(string.Empty, "Email veya şifre hatalı");
            }

			ViewBag.success = "Giriş başarılı";
			return View();

        }
	}
}
