using AutoMapper.Internal.Mappers;
using Karma.API.Mapping;
using Karma.API.Models.BrandModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.CommonLayer.Enums;
using Karma.DtoLayer.Dtos.BrandDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerExtensions
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _brandService.TGetListAsync();
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _brandService.TGetByIdAsync(id);
            var responseType = Enum.GetName(typeof(ResponseType), values.ResponseType);
            return TGetBaseActionInstance(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandViewModel request)
        {
            var createBrand = ObjectMapperAPI.mapper.Map<CreateBrandDto>(request);
            var values = await _brandService.TAddAsync(createBrand);
            return TPostActionInstance(values);
        }
        [HttpPut]
        public IActionResult UpdateBrand(UpdateBrandViewModel request)
        {
            var updateBrand = ObjectMapperAPI.mapper.Map<UpdateBrandDto>(request);
            var value = _brandService.TUpdate(updateBrand);
            return TPutActionInstance(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var value =await _brandService.TDeleteAsync(id);
            return Ok(value);
        }
    }
}
