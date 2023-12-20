using Karma.API.Mapping;
using Karma.API.Models.ContactModel;
using Karma.API.Models.ServiceModel;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.DtoLayer.Dtos.ContactDto;
using Karma.DtoLayer.Dtos.ServiceDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karma.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ContactController : ControllerExtensions
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var values = await _contactService.TGetListAsync();
			return TGetBaseActionInstance(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactViewModel model)
		{
			var result = await _contactService.TAddAsync(ObjectMapperAPI.mapper.Map<CreateContactDto>(model));
			return TPostActionInstance(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetService(int id)
		{
			var value = await _contactService.TGetByIdAsync(id);
			return TGetBaseActionInstance(value);
		}
		[HttpPut]
		public IActionResult UpdateService(UpdateContactViewModel model)
		{
			var value = _contactService.TUpdate(ObjectMapperAPI.mapper.Map<UpdateContactDto>(model));

			return TPutActionInstance(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteService(int id)
		{
			var value = await _contactService.TDeleteAsync(id);
			return Ok(value);
		}
	}
}
