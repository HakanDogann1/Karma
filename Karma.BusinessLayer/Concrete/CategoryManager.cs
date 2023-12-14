using AutoMapper.Internal.Mappers;
using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.BusinessLayer.ValidationRules.FluentValidations.NumberValidations;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.CategoryDto;
using Karma.DtoLayer.Dtos.NumberDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IValidator<CreateCategoryDto> _createCategoryValidator;
        private readonly IValidator<UpdateCategoryDto> _updateCategoryValidator;
        private readonly IUow _uow;

        public CategoryManager(ICategoryDal categoryDal, IValidator<CreateCategoryDto> createCategoryValidator, IValidator<UpdateCategoryDto> updateCategoryValidator, IUow uow)
        {
            _categoryDal = categoryDal;
            _createCategoryValidator = createCategoryValidator;
            _updateCategoryValidator = updateCategoryValidator;
            _uow = uow;
        }

        public async Task<Response<CreateCategoryDto>> TAddAsync(CreateCategoryDto entity)
        {
            var validate = _createCategoryValidator.Validate(entity);
            if(!validate.IsValid)
            {
                return new Response<CreateCategoryDto>(entity,validate.CustomValidationError());
            }
            var createCategory = ObjectMapper.mapper.Map<Category>(entity);
            await _categoryDal.AddAsync(createCategory);
            await _uow.CommitAsync();
            return new Response<CreateCategoryDto>(entity);
        }

        public async Task<Response> TDeleteAsync(int id)
        {
            await _categoryDal.DeleteAsync(id);
            await _uow.CommitAsync();
            return new Response(CommonLayer.Enums.ResponseType.Success);
        }

        public Response<IQueryable<ResultCategoryDto>> TGetByFilter(Expression<Func<Category, bool>> filter)
        {
            var value = _categoryDal.GetByFilter(filter);
            if (!value.Any())
            {
                return new Response<IQueryable<ResultCategoryDto>>("Aradığınız numara bulunamadı", ResponseType.Fail);
            }
            var resultNumber = ObjectMapper.mapper.Map<IQueryable<ResultCategoryDto>>(value);
            return new Response<IQueryable<ResultCategoryDto>>(resultNumber);
        }

        public async Task<Response<ResultCategoryDto>> TGetByIdAsync(int id)
        {
            var value = await _categoryDal.GetByIdAsync(id);
            if (value == null)
            {
                return new Response<ResultCategoryDto>("Numara bulunamadı", ResponseType.Fail);
            }
            var resultNumber = ObjectMapper.mapper.Map<ResultCategoryDto>(value);
            return new Response<ResultCategoryDto>(resultNumber);
        }

        public async Task<Response<IEnumerable<ResultCategoryDto>>> TGetListAsync()
        {
            var values = await _categoryDal.GetListAsync();
            var resultNumber = ObjectMapper.mapper.Map<IEnumerable<ResultCategoryDto>>(values);
            return new Response<IEnumerable<ResultCategoryDto>>(resultNumber);
        }

        public Response<UpdateCategoryDto> TUpdate(UpdateCategoryDto entity)
        {
            var validate = _updateCategoryValidator.Validate(entity);
            if (!validate.IsValid)
            {
                return new Response<UpdateCategoryDto>(entity, validate.CustomValidationError());
            }
            _categoryDal.Update(ObjectMapper.mapper.Map<Category>(entity));
            _uow.Commit();
            return new Response<UpdateCategoryDto>(entity);
        }
    }
}
