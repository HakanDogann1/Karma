using Karma.PresentetionLayer.Models.ContactViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
	public class ContactPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateContactViewModel model)
		{

			return View();
		}
	}
}
