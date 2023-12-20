using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageCategoryViewComponent")]
	public class HomePageCategoryViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
