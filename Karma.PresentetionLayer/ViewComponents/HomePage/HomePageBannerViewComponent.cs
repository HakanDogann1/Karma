using Karma.PresentetionLayer.Models.NewCollectionViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageBannerViewComponent")]
	public class HomePageBannerViewComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HomePageBannerViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7015/api/NewCollection/GetList");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<List<ResultNewCollectionViewModel>>(jsonData);
				return View(data);
			}
			return View();
		}
	}
}
