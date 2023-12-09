using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IValidator<CreateBrandDto> _createBrandValidator;
        private readonly IValidator<UpdateBrandDto> _updateBrandValidator;
        private readonly IUow _uow;
        public BrandManager(IBrandDal brandDal, IValidator<CreateBrandDto> createBrandValidator, IUow uow, IValidator<UpdateBrandDto> updateBrandValidator)
        {
            _brandDal = brandDal;
            _createBrandValidator = createBrandValidator;
            _uow = uow;
            _updateBrandValidator = updateBrandValidator;
        }
        // ValidationExtensions ve Validate işlemi yapılacak.

        public async Task<Response<CreateBrandDto>> TAddAsync(CreateBrandDto entity)
        {
            var validate = _createBrandValidator.Validate(entity);
            if(!validate.IsValid)
            {
                return new Response<CreateBrandDto>(entity, validate.CustomValidationError());
            }
            var brand = ObjectMapper.mapper.Map<Brand>(entity);
            await _brandDal.AddAsync(brand);
            await _uow.CommitAsync();
            return new Response<CreateBrandDto>(entity,"Başarıyla eklendi");
        }

        public async Task<Response> TDeleteAsync(int id)
        {
            await _brandDal.DeleteAsync(id);
            await _uow.CommitAsync();
            return new Response("Başarıyla silindi",ResponseType.Success);
        }

        public Response<IQueryable<ResultBrandDto>> TGetByFilter(Expression<Func<Brand, bool>> filter)
        {
           var values = _brandDal.GetByFilter(filter);
            var resultBrand = ObjectMapper.mapper.Map<List<ResultBrandDto>>(values).AsQueryable();
            if (values == null)
            {
                return new Response<IQueryable<ResultBrandDto>>(resultBrand, "Veri bulunamadı");
            }
            return new Response<IQueryable<ResultBrandDto>>(resultBrand);
        }

        public async Task<Response<ResultBrandDto>> TGetByIdAsync(int id)
        {
            var value = await _brandDal.GetByIdAsync(id);
            if(value== null)
            {
                return new Response<ResultBrandDto>("Veri getirilemedi", ResponseType.Fail);
            }
            var resultBrand = ObjectMapper.mapper.Map<ResultBrandDto>(value);
            return new Response<ResultBrandDto>(resultBrand);
        }

        public async Task<Response<IEnumerable<ResultBrandDto>>> TGetListAsync()
        {
            var value = await _brandDal.GetListAsync();
            var resultBrand = ObjectMapper.mapper.Map<List<ResultBrandDto>>(value);
            return new Response<IEnumerable<ResultBrandDto>>(resultBrand);
            
        }

        public Response<UpdateBrandDto> TUpdate(UpdateBrandDto entity)
        {
            var validate = _updateBrandValidator.Validate(entity);
            if(!validate.IsValid)
            {
                return new Response<UpdateBrandDto>(entity, validate.CustomValidationError());
            }
            var updateBrand = ObjectMapper.mapper.Map<Brand>(entity);
            _brandDal.Update(updateBrand);
            _uow.Commit();
            return new Response<UpdateBrandDto>(entity,"Başarıyla güncellendi");
        }
    }
}
