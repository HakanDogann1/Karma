using Karma.PresentetionLayer.Areas.Admin.Models.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Claims()
        {
            var userClaimList = User.Claims.Select(x=>new ClaimViewModel() { Issuer=x.Issuer,Type=x.Type,Value=x.Value}).ToList();
            return View(userClaimList);
        }

        [Authorize(Policy ="KarabükPolicy")]
        public IActionResult KarabükPage()
        {
            return View();
        }
    }
}
