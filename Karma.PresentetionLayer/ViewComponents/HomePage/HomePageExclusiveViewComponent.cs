using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageExclusiveViewComponent")]
	public class HomePageExclusiveViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
