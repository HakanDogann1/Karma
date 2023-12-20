using Karma.API.Mapping;
using Karma.API.Models.NewCollectionModel;
using Karma.API.Models.ServiceModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using Karma.DtoLayer.Dtos.ServiceDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class NewCollectionController : ControllerExtensions
	{
		private readonly INewCollectionService _collectionService;

		public NewCollectionController(INewCollectionService collectionService)
		{
			_collectionService = collectionService;
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var values = await _collectionService.TGetListAsync();
			return TGetBaseActionInstance(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateNewCollection(CreateNewCollectionViewModel model)
		{
			var result = await _collectionService.TAddAsync(ObjectMapperAPI.mapper.Map<CreateNewCollectionDto>(model));
			return TPostActionInstance(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetNewCollection(int id)
		{
			var value = await _collectionService.TGetByIdAsync(id);
			return TGetBaseActionInstance(value);
		}
		[HttpPut]
		public IActionResult UpdateService(UpdateNewCollectionViewModel model)
		{
			var value = _collectionService.TUpdate(ObjectMapperAPI.mapper.Map<UpdateNewCollectionDto>(model));

			return TPutActionInstance(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteNewCollection(int id)
		{
			var value = await _collectionService.TDeleteAsync(id);
			return Ok(value);
		}

	}
}
