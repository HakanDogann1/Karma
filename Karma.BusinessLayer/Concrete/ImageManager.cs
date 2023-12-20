using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ServiceValidations;
using Karma.CommonLayer.Enums;
using Karma.CommonLayer;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.ImageDto;
using Karma.DtoLayer.Dtos.ServiceDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.BusinessLayer.Mapping;

namespace Karma.BusinessLayer.Concrete
{
	public class ImageManager:IImageService
	{
		private readonly IImageDal _imageDal;
		private readonly IValidator<CreateImageDto> _createImageValidator;
		private readonly IValidator<UpdateImageDto> _updateImageValidator;
		private readonly IUow _uow;

		public ImageManager(IImageDal imageDal, IValidator<CreateImageDto> createImageValidator, IValidator<UpdateImageDto> updateImageValidator, IUow uow)
		{
			_imageDal = imageDal;
			_createImageValidator = createImageValidator;
			_updateImageValidator = updateImageValidator;
			_uow = uow;
		}
		public async Task<Response<CreateImageDto>> TAddAsync(CreateImageDto entity)
		{
			var validate = _createImageValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<CreateImageDto>(entity, validate.CustomValidationError());
			}
			var image = ObjectMapper.mapper.Map<Image>(entity);
			await _imageDal.AddAsync(image);
			await _uow.CommitAsync();
			return new Response<CreateImageDto>(entity, "Başarıyla eklendi");
		}
		public async Task<Response> TDeleteAsync(int id)
		{
			await _imageDal.DeleteAsync(id);
			await _uow.CommitAsync();
			return new Response("Başarıyla silindi", ResponseType.Success);
		}
		public Response<IQueryable<ResultImageDto>> TGetByFilter(Expression<Func<Image, bool>> filter)
		{
			var values = _imageDal.GetByFilter(filter);
			var resultService = ObjectMapper.mapper.Map<List<ResultImageDto>>(values).AsQueryable();
			if (values == null)
			{
				return new Response<IQueryable<ResultImageDto>>(resultService, "Veri bulunamadı");
			}
			return new Response<IQueryable<ResultImageDto>>(resultService);
		}

		public async Task<Response<ResultImageDto>> TGetByIdAsync(int id)
		{
			var value = await _imageDal.GetByIdAsync(id);
			if (value == null)
			{
				return new Response<ResultImageDto>("Veri getirilemedi", ResponseType.Fail);
			}
			var resultService = ObjectMapper.mapper.Map<ResultImageDto>(value);
			return new Response<ResultImageDto>(resultService);
		}

		public async Task<Response<IEnumerable<ResultImageDto>>> TGetListAsync()
		{
			var value = await _imageDal.GetListAsync();
			var resultService = ObjectMapper.mapper.Map<List<ResultImageDto>>(value);
			return new Response<IEnumerable<ResultImageDto>>(resultService);

		}

		public Response<UpdateImageDto> TUpdate(UpdateImageDto entity)
		{
			var validate = _updateImageValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<UpdateImageDto>(entity, validate.CustomValidationError());
			}
			var updateImage = ObjectMapper.mapper.Map<Image>(entity);
			_imageDal.Update(updateImage);
			_uow.Commit();
			return new Response<UpdateImageDto>(entity, "Başarıyla güncellendi");
		}
	}
}
