using Karma.PresentetionLayer.Extensions;
using Karma.PresentetionLayer.Models;
using Karma.PresentetionLayer.Models.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Karma.PresentetionLayer.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Silindi"] = "asd";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7015/api/Category/GetList");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData);
                return View(data);
            }
           
            return View();
           
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryViewModel);
            var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7015/api/Category/CreateCategory", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            var jsonErrorData = await response.Content.ReadAsStringAsync();
            var errorData = JsonConvert.DeserializeObject<List<CustomError>>(jsonErrorData);
            ModelState.AddModelErrorList(errorData);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7015/api/Category/GetById?id={id}");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateCategoryViewModel>(jsonData);
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryViewModel);
            var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PutAsync("https://localhost:7015/api/Category/UpdateCategory",stringContent);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            var errorJsonData = await response.Content.ReadAsStringAsync();
            var errorData = JsonConvert.DeserializeObject<List<CustomError>>(errorJsonData);

            ModelState.AddModelErrorList(errorData);
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            TempData["Silindi"] ="Kategori silindi.";
            var client = _httpClientFactory.CreateClient();
            var jsonData = await client.DeleteAsync($"https://localhost:7015/api/Category/DeleteCategory?id={id}");
            if(jsonData.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
