using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound(int statusCode)
        {
            return View();
        }
    }
}
