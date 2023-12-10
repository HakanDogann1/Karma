using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IValidator<CreateColorDto> _createColorValidator;
        private readonly IValidator<UpdateColorDto> _updateColorValidator;
        private readonly IUow _uow;
        public ColorManager(IColorDal colorDal, IValidator<CreateColorDto> createColorValidator, IUow uow, IValidator<UpdateColorDto> updateColorValidator)
        {
            _colorDal = colorDal;
            _createColorValidator = createColorValidator;
            _uow = uow;
            _updateColorValidator = updateColorValidator;
        }

        public async Task<Response<CreateColorDto>> TAddAsync(CreateColorDto entity)
        {
            var validate = _createColorValidator.Validate(entity);
            if(!validate.IsValid)
            {
                return new Response<CreateColorDto>(entity, validate.CustomValidationError());
            }
            var newColor = ObjectMapper.mapper.Map<Color>(entity);
            var value = await _colorDal.AddAsync(newColor);
            await _uow.CommitAsync();
            return new Response<CreateColorDto>(entity,"Kayıt başarıyla tamamlandı");
            
        }

        public async Task<Response> TDeleteAsync(int id)
        {
            await _colorDal.DeleteAsync(id);
            await _uow.CommitAsync();
            return new Response(CommonLayer.Enums.ResponseType.Success);
        }

        public Response<IQueryable<ResultColorDto>> TGetByFilter(Expression<Func<Color, bool>> filter)
        {
            var value = _colorDal.GetByFilter(filter);
            if(value == null)
            {
                return new Response<IQueryable<ResultColorDto>>("Renk Bulunamadı", ResponseType.Fail);
            }
            var newEntity = ObjectMapper.mapper.Map<IQueryable<ResultColorDto>>(value);
            return new Response<IQueryable<ResultColorDto>>(newEntity);
        }

        public async Task<Response<ResultColorDto>> TGetByIdAsync(int id)
        {
            var value = await _colorDal.GetByIdAsync(id);
            if (value == null)
            {
                return new Response<ResultColorDto>("Veri getirilemedi", ResponseType.Fail);
            }
            var resultColor = ObjectMapper.mapper.Map<ResultColorDto>(value);
            return new Response<ResultColorDto>(resultColor);
        }

        public async Task<Response<IEnumerable<ResultColorDto>>> TGetListAsync()
        {

            var value = await _colorDal.GetListAsync();
            var resultColor = ObjectMapper.mapper.Map<List<ResultColorDto>>(value);
            return new Response<IEnumerable<ResultColorDto>>(resultColor);
        }

        public Response<UpdateColorDto> TUpdate(UpdateColorDto entity)
        {
            var validate = _updateColorValidator.Validate(entity);
            if (!validate.IsValid)
            {
                return new Response<UpdateColorDto>(entity, validate.CustomValidationError());
            }
            var updateColor = ObjectMapper.mapper.Map<Color>(entity);
             _colorDal.Update(updateColor);
            _uow.Commit();
            return new Response<UpdateColorDto>(entity, "Başarıyla güncellendi");
        }
    }
}
