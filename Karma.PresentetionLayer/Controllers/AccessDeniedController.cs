using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
