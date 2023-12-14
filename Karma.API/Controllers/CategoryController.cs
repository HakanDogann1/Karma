using Karma.API.Mapping;
using Karma.API.Models.CategoryModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.CommonLayer.Enums;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.CategoryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerExtensions
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _categoryService.TGetListAsync();
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _categoryService.TGetByIdAsync(id);
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel request)
        {
            var createBrand = ObjectMapperAPI.mapper.Map<CreateCategoryDto>(request);
            var values = await _categoryService.TAddAsync(createBrand);
            return TPostActionInstance(values);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryViewModel request)
        {
            var updateBrand = ObjectMapperAPI.mapper.Map<UpdateCategoryDto>(request);
            var value = _categoryService.TUpdate(updateBrand);
            return TPutActionInstance(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _categoryService.TDeleteAsync(id);
            return Ok(value);
        }
    }
}
