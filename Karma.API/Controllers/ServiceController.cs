using Karma.API.Mapping;
using Karma.API.Models.ServiceModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.DtoLayer.Dtos.ServiceDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ServiceController : ControllerExtensions
	{
		private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var values = await _serviceService.TGetListAsync();
			return TGetBaseActionInstance(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceViewModel model)
		{
			var result = await _serviceService.TAddAsync(ObjectMapperAPI.mapper.Map<CreateServiceDto>(model));
			return TPostActionInstance(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetService(int id)
		{
			var value = await _serviceService.TGetByIdAsync(id);
			return TGetBaseActionInstance(value);
		}
		[HttpPut]
		public IActionResult UpdateService(UpdateServiceViewModel model)
		{
			var value = _serviceService.TUpdate(ObjectMapperAPI.mapper.Map<UpdateServiceDto>(model));

			return TPutActionInstance(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteService(int id)
		{
			var value = await _serviceService.TDeleteAsync(id);
			return Ok(value);
		}
	}
}
