using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ImageValidations;
using Karma.CommonLayer.Enums;
using Karma.CommonLayer;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.ImageDto;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.BusinessLayer.Mapping;
using Karma.EntityLayer.Concrete;

namespace Karma.BusinessLayer.Concrete
{
	public class NewCollectionManager:INewCollectionService
	{
		private readonly INewCollectionDal _newCollectionDal;
		private readonly IValidator<CreateNewCollectionDto> _createNewCollectionValidator;
		private readonly IValidator<UpdateNewCollectionDto> _updateNewCollectionValidator;
		private readonly IUow _uow;

		public NewCollectionManager(INewCollectionDal newCollectionDal, IValidator<CreateNewCollectionDto> createNewCollectionValidator, IValidator<UpdateNewCollectionDto> updateNewCollectionValidator, IUow uow)
		{
			_newCollectionDal = newCollectionDal;
			_createNewCollectionValidator = createNewCollectionValidator;
			_updateNewCollectionValidator = updateNewCollectionValidator;
			_uow = uow;
		}
		public async Task<Response<CreateNewCollectionDto>> TAddAsync(CreateNewCollectionDto entity)
		{
			var validate = _createNewCollectionValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<CreateNewCollectionDto>(entity, validate.CustomValidationError());
			}
			var newCollection = ObjectMapper.mapper.Map<NewCollection>(entity);
			await _newCollectionDal.AddAsync(newCollection);
			await _uow.CommitAsync();
			return new Response<CreateNewCollectionDto>(entity, "Başarıyla eklendi");
		}
		public async Task<Response> TDeleteAsync(int id)
		{
			await _newCollectionDal.DeleteAsync(id);
			await _uow.CommitAsync();
			return new Response("Başarıyla silindi", ResponseType.Success);
		}
		public Response<IQueryable<ResultNewCollectionDto>> TGetByFilter(Expression<Func<NewCollection, bool>> filter)
		{
			var values = _newCollectionDal.GetByFilter(filter);
			var resultNewCollection = ObjectMapper.mapper.Map<List<ResultNewCollectionDto>>(values).AsQueryable();
			if (values == null)
			{
				return new Response<IQueryable<ResultNewCollectionDto>>(resultNewCollection, "Veri bulunamadı");
			}
			return new Response<IQueryable<ResultNewCollectionDto>>(resultNewCollection);
		}

		public async Task<Response<ResultNewCollectionDto>> TGetByIdAsync(int id)
		{
			var value = await _newCollectionDal.GetByIdAsync(id);
			if (value == null)
			{
				return new Response<ResultNewCollectionDto>("Veri getirilemedi", ResponseType.Fail);
			}
			var resultNewCollection = ObjectMapper.mapper.Map<ResultNewCollectionDto>(value);
			return new Response<ResultNewCollectionDto>(resultNewCollection);
		}

		public async Task<Response<IEnumerable<ResultNewCollectionDto>>> TGetListAsync()
		{
			var value = await _newCollectionDal.GetListAsync();
			var resultNewCollection = ObjectMapper.mapper.Map<List<ResultNewCollectionDto>>(value);
			return new Response<IEnumerable<ResultNewCollectionDto>>(resultNewCollection);

		}

		public Response<UpdateNewCollectionDto> TUpdate(UpdateNewCollectionDto entity)
		{
			var validate = _updateNewCollectionValidator.Validate(entity);
			if (!validate.IsValid)
			{
				return new Response<UpdateNewCollectionDto>(entity, validate.CustomValidationError());
			}
			var updateNewCollection = ObjectMapper.mapper.Map<NewCollection>(entity);
			_newCollectionDal.Update(updateNewCollection);
			_uow.Commit();
			return new Response<UpdateNewCollectionDto>(entity, "Başarıyla güncellendi");
		}
	}
}
