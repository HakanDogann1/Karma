using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageRelatedProductViewModel")]
	public class HomePageRelatedProductViewModel:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
