using Karma.API.Mapping;
using Karma.API.Models.ColorModel;
using Karma.API.Models.NumberModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.CommonLayer.Enums;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.DtoLayer.Dtos.NumberDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NumberController : ControllerExtensions
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService = numberService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _numberService.TGetListAsync();
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _numberService.TGetByIdAsync(id);
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNumber(CreateNumberViewModel request)
        {
            var createBrand = ObjectMapperAPI.mapper.Map<CreateNumberDto>(request);
            var values = await _numberService.TAddAsync(createBrand);
            return TPostActionInstance(values);
        }
        [HttpPut]
        public IActionResult UpdateNumber(UpdateNumberViewModel request)
        {
            var updateBrand = ObjectMapperAPI.mapper.Map<UpdateNumberDto>(request);
            var value = _numberService.TUpdate(updateBrand);
            return TPutActionInstance(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteNumber(int id)
        {
            var value = await _numberService.TDeleteAsync(id);
            return Ok(value);
        }
    }
}
