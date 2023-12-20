using Karma.API.Mapping;
using Karma.API.Models.ImageModel;
using Karma.API.Models.NewCollectionModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.DtoLayer.Dtos.ImageDto;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ImageController : ControllerExtensions
	{
		private readonly IImageService _imageService;

		public ImageController(IImageService imageService)
		{
			_imageService = imageService;
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var values = await _imageService.TGetListAsync();
			return TGetBaseActionInstance(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateImage(CreateImageViewModel model)
		{
			var result = await _imageService.TAddAsync(ObjectMapperAPI.mapper.Map<CreateImageDto>(model));
			return TPostActionInstance(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetImage(int id)
		{
			var value = await _imageService.TGetByIdAsync(id);
			return TGetBaseActionInstance(value);
		}
		[HttpPut]
		public IActionResult UpdateImage(UpdateImageViewModel model)
		{
			var value = _imageService.TUpdate(ObjectMapperAPI.mapper.Map<UpdateImageDto>(model));

			return TPutActionInstance(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteImage(int id)
		{
			var value = await _imageService.TDeleteAsync(id);
			return Ok(value);
		}
	}
}
