using Karma.PresentetionLayer.Models.BrandViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Karma.PresentetionLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7015/api/Brand/GetList");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<ResultBrandViewModel>>(jsonData);
                return View(Data);
            }
            return View();
        }

        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandViewModel request)
        {
            var client = _httpClientFactory.CreateClient();
            request.Piece = 100;
            var jsonData = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7015/api/Brand/CreateBrand", stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7015/api/Brand/GetById?id={id}");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateBrandViewModel>(jsonData);
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandViewModel request)
        {
            var client = _httpClientFactory.CreateClient();
            request.Piece = 100;
            var jsonData = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7015/api/Brand/UpdateBrand", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7015/api/Brand/DeleteBrand?id={id}");
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
