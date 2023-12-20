using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageBrandViewComponent")]
	public class HomePageBrandViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke() { return View(); }
	}
}
