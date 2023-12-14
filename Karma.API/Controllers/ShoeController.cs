using Karma.API.Mapping;
using Karma.API.Models.NumberModel;
using Karma.API.Models.ShoeModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.CommonLayer.Enums;
using Karma.DtoLayer.Dtos.NumberDto;
using Karma.DtoLayer.Dtos.ShoeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoeController : ControllerExtensions
    {
        private readonly IShoeService _shoeService;

        public ShoeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _shoeService.TGetListAsync();
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _shoeService.TGetByIdAsync(id);
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShoe(CreateShoeViewModel request)
        {
            var createBrand = ObjectMapperAPI.mapper.Map<CreateShoeDto>(request);
            var values = await _shoeService.TAddAsync(createBrand);
            return TPostActionInstance(values);
        }
        [HttpPut]
        public IActionResult UpdateShoe(UpdateShoeViewModel request)
        {
            var updateBrand = ObjectMapperAPI.mapper.Map<UpdateShoeDto>(request);
            var value = _shoeService.TUpdate(updateBrand);
            return TPutActionInstance(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShoe(int id)
        {
            var value = await _shoeService.TDeleteAsync(id);
            return Ok(value);
        }
    }
}
