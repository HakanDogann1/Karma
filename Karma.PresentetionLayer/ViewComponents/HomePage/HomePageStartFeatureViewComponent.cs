using Karma.PresentetionLayer.Models.NewCollectionViewModel;
using Karma.PresentetionLayer.Models.ServiceViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Karma.PresentetionLayer.ViewComponents.HomePage
{
	[ViewComponent(Name = "HomePageStartFeatureViewComponent")]
	public class HomePageStartFeatureViewComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HomePageStartFeatureViewComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7015/api/Service/GetList");
			if(response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<List<ResultServiceViewModel>>(jsonData);
				return View(data);
			}
			return View();
		}
	}
}
