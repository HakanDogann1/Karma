using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ServiceValidations;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.BrandDto;
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
	public class ServiceManager : IServiceService
	{
		private readonly IServiceDal _serviceDal;
		private readonly IValidator<CreateServiceDto> _createServiceValidator;
		private readonly IValidator<UpdateServiceDto> _updateServiceValidator;
		private readonly IUow _uow;
		public ServiceManager(IServiceDal serviceDal, IValidator<CreateServiceDto> createServiceValidator, IUow uow, IValidator<UpdateServiceDto> updateServiceValidator)
		{
			_serviceDal = serviceDal;
			_createServiceValidator = createServiceValidator;
			_uow = uow;
			_updateServiceValidator = updateServiceValidator;
		}

		public async Task<Response<CreateServiceDto>> TAddAsync(CreateServiceDto entity)
		{
			var validate = _createServiceValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<CreateServiceDto>(entity, validate.CustomValidationError());
			}
			var service = ObjectMapper.mapper.Map<Service>(entity);
			await _serviceDal.AddAsync(service);
			await _uow.CommitAsync();
			return new Response<CreateServiceDto>(entity, "Başarıyla eklendi");
		}
		public async Task<Response> TDeleteAsync(int id)
		{
			await _serviceDal.DeleteAsync(id);
			await _uow.CommitAsync();
			return new Response("Başarıyla silindi", ResponseType.Success);
		}
		public Response<IQueryable<ResultServiceDto>> TGetByFilter(Expression<Func<Service, bool>> filter)
		{
			var values = _serviceDal.GetByFilter(filter);
			var resultService = ObjectMapper.mapper.Map<List<ResultServiceDto>>(values).AsQueryable();
			if (values == null)
			{
				return new Response<IQueryable<ResultServiceDto>>(resultService, "Veri bulunamadı");
			}
			return new Response<IQueryable<ResultServiceDto>>(resultService);
		}

		public async Task<Response<ResultServiceDto>> TGetByIdAsync(int id)
		{
			var value = await _serviceDal.GetByIdAsync(id);
			if (value == null)
			{
				return new Response<ResultServiceDto>("Veri getirilemedi", ResponseType.Fail);
			}
			var resultService = ObjectMapper.mapper.Map<ResultServiceDto>(value);
			return new Response<ResultServiceDto>(resultService);
		}

		public async Task<Response<IEnumerable<ResultServiceDto>>> TGetListAsync()
		{
			var value = await _serviceDal.GetListAsync();
			var resultService = ObjectMapper.mapper.Map<List<ResultServiceDto>>(value);
			return new Response<IEnumerable<ResultServiceDto>>(resultService);

		}

		public Response<UpdateServiceDto> TUpdate(UpdateServiceDto entity)
		{
			var validate = _updateServiceValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<UpdateServiceDto>(entity, validate.CustomValidationError());
			}
			var updateService = ObjectMapper.mapper.Map<Service>(entity);
			_serviceDal.Update(updateService);
			_uow.Commit();
			return new Response<UpdateServiceDto>(entity, "Başarıyla güncellendi");
		}
	}
}
