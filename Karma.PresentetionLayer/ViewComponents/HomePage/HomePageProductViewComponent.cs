using Karma.PresentetionLayer.Models.ShoeViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageProductViewComponent")]
	public class HomePageProductViewComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HomePageProductViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7015/api/Shoe/GetList");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<List<ResultShoeViewModel>>(jsonData);
				return View(data);
			}
			return View();
		}
	}
}
