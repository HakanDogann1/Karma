using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
    public class AdminLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult _SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
    }
}
