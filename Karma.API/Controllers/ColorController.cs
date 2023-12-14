using Karma.API.Mapping;
using Karma.API.Models.ColorModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.CommonLayer.Enums;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.ColorDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColorController : ControllerExtensions
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _colorService.TGetListAsync();
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _colorService.TGetByIdAsync(id);
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor(CreateColorViewModel request)
        {
            var createBrand = ObjectMapperAPI.mapper.Map<CreateColorDto>(request);
            var values = await _colorService.TAddAsync(createBrand);
            return TPostActionInstance(values);
        }
        [HttpPut]
        public IActionResult UpdateColor(UpdateColorViewModel request)
        {
            var updateBrand = ObjectMapperAPI.mapper.Map<UpdateColorDto>(request);
            var value = _colorService.TUpdate(updateBrand);
            return TPutActionInstance(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var value = await _colorService.TDeleteAsync(id);
            return Ok(value);
        }
    }
}
