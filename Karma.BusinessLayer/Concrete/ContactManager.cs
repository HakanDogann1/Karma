using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ServiceValidations;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.ContactDto;
using Karma.DtoLayer.Dtos.ServiceDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;
		private readonly IValidator<UpdateContactDto> _updateContactValidator;
		private readonly IValidator<CreateContactDto> _createContactValidator;
		private readonly IUow _uow;

		public ContactManager(IContactDal contactDal, IValidator<UpdateContactDto> updateContactValidator, IValidator<CreateContactDto> createContactValidator, IUow uow)
		{
			_contactDal = contactDal;
			_updateContactValidator = updateContactValidator;
			_createContactValidator = createContactValidator;
			_uow = uow;
		}

		public async Task<Response<CreateContactDto>> TAddAsync(CreateContactDto entity)
		{
			var validate = _createContactValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<CreateContactDto>(entity, validate.CustomValidationError());
			}
			var contact = ObjectMapper.mapper.Map<Contact>(entity);
			await _contactDal.AddAsync(contact);
			await _uow.CommitAsync();
			return new Response<CreateContactDto>(entity, "Başarıyla eklendi");
		}
		public async Task<Response> TDeleteAsync(int id)
		{
			await _contactDal.DeleteAsync(id);
			await _uow.CommitAsync();
			return new Response("Başarıyla silindi", ResponseType.Success);
		}
		public Response<IQueryable<ResultContactDto>> TGetByFilter(Expression<Func<Contact, bool>> filter)
		{
			var values = _contactDal.GetByFilter(filter);
			var resultContact = ObjectMapper.mapper.Map<List<ResultContactDto>>(values).AsQueryable();
			if (values == null)
			{
				return new Response<IQueryable<ResultContactDto>>(resultContact, "Veri bulunamadı");
			}
			return new Response<IQueryable<ResultContactDto>>(resultContact);
		}

		public async Task<Response<ResultContactDto>> TGetByIdAsync(int id)
		{
			var value = await _contactDal.GetByIdAsync(id);
			if (value == null)
			{
				return new Response<ResultContactDto>("Veri getirilemedi", ResponseType.Fail);
			}
			var resultContact = ObjectMapper.mapper.Map<ResultContactDto>(value);
			return new Response<ResultContactDto>(resultContact);
		}

		public async Task<Response<IEnumerable<ResultContactDto>>> TGetListAsync()
		{
			var value = await _contactDal.GetListAsync();
			var resultContact = ObjectMapper.mapper.Map<List<ResultContactDto>>(value);
			return new Response<IEnumerable<ResultContactDto>>(resultContact);

		}

		public Response<UpdateContactDto> TUpdate(UpdateContactDto entity)
		{
			var validate = _updateContactValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<UpdateContactDto>(entity, validate.CustomValidationError());
			}
			var updateContact = ObjectMapper.mapper.Map<Contact>(entity);
			_contactDal.Update(updateContact);
			_uow.Commit();
			return new Response<UpdateContactDto>(entity, "Başarıyla güncellendi");
		}
	}
}
