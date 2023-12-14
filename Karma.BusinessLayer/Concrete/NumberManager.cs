using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.BusinessLayer.ValidationRules.FluentValidations.NumberValidations;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.UnitOfWork;
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
    public class NumberManager : INumberService
    {
        private readonly INumberDal _numberDal;
        private readonly IValidator<CreateNumberDto> _createNumberValidator;
        private readonly IValidator<UpdateNumberDto> _updateNumberValidator;
        private readonly IUow _uow;
        public NumberManager(INumberDal numberDal, IValidator<CreateNumberDto> createNumberValidator, IUow uow, IValidator<UpdateNumberDto> updateNumberValidator)
        {
            _numberDal = numberDal;
            _createNumberValidator = createNumberValidator;
            _uow = uow;
            _updateNumberValidator = updateNumberValidator;
        }

        public async Task<Response<CreateNumberDto>> TAddAsync(CreateNumberDto entity)
        {
            var number = ObjectMapper.mapper.Map<Number>(entity);
            var result = _createNumberValidator.Validate(entity);
            if(!result.IsValid)
            {
                return new Response<CreateNumberDto>(entity, result.CustomValidationError());
            }
            await _numberDal.AddAsync(number);
            await _uow.CommitAsync();

            return new Response<CreateNumberDto>(entity,"İşlem Başarılı");
        }

        public async Task<Response> TDeleteAsync(int id)
        {
            await _numberDal.DeleteAsync(id);
            await _uow.CommitAsync();
            return new Response(CommonLayer.Enums.ResponseType.Success);
        }

        public Response<IQueryable<ResultNumberDto>> TGetByFilter(Expression<Func<Number, bool>> filter)
        {
            var value = _numberDal.GetByFilter(filter);
            if (!value.Any())
            {
                return new Response<IQueryable<ResultNumberDto>>("Aradığınız numara bulunamadı",ResponseType.Fail);
            }
            var resultNumber = ObjectMapper.mapper.Map<IQueryable<ResultNumberDto>>(value);
            return new Response<IQueryable<ResultNumberDto>>(resultNumber);
        }

        public async Task<Response<ResultNumberDto>> TGetByIdAsync(int id)
        {
            var value = await _numberDal.GetByIdAsync(id);
            if (value==null)
            {
                return new Response<ResultNumberDto>("Numara bulunamadı", ResponseType.Fail);
            }
            var resultNumber = ObjectMapper.mapper.Map<ResultNumberDto>(value);
            return new Response<ResultNumberDto>(resultNumber);
        }

        public async Task<Response<IEnumerable<ResultNumberDto>>> TGetListAsync()
        {
            var values = await _numberDal.GetListAsync();
            if (!values.Any())
            {
                return new Response<IEnumerable<ResultNumberDto>>("Liste boş", ResponseType.Fail);
            }
            var resultNumber = ObjectMapper.mapper.Map<IEnumerable<ResultNumberDto>>(values);
            return new Response<IEnumerable<ResultNumberDto>>(resultNumber);
        }

        public Response<UpdateNumberDto> TUpdate(UpdateNumberDto entity)
        {
            var validate = _updateNumberValidator.Validate(entity);
            if (!validate.IsValid)
            {
                return new Response<UpdateNumberDto>(entity, validate.CustomValidationError());
            }
            _numberDal.Update(ObjectMapper.mapper.Map<Number>(entity));
            _uow.Commit();
            return new Response<UpdateNumberDto>(entity);
        }
    }
}
