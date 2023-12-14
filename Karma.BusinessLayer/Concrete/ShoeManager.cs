using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Extensions;
using Karma.BusinessLayer.Mapping;
using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
    public class ShoeManager : IShoeService
    {
        private readonly IShoeDal _shoeDal;
        private readonly IValidator<UpdateShoeDto> _updateShoeValidator;
        private readonly IValidator<CreateShoeDto> _createShoeValidator;
        private readonly IUow _uow;
        public ShoeManager(IShoeDal shoeDal, IValidator<UpdateShoeDto> updateShoeValidator, IValidator<CreateShoeDto> createShoeValidator, IUow uow)
        {
            _shoeDal = shoeDal;
            _updateShoeValidator = updateShoeValidator;
            _createShoeValidator = createShoeValidator;
            _uow = uow;
        }

        public async Task<Response<CreateShoeDto>> TAddAsync(CreateShoeDto entity)
        {
            var validate = _createShoeValidator.Validate(entity);
            if (!validate.IsValid)
            {
                return new Response<CreateShoeDto>(entity, validate.CustomValidationError());
            }
            var Shoe = ObjectMapper.mapper.Map<Shoe>(entity);
            await _shoeDal.AddAsync(Shoe);
            await _uow.CommitAsync();
            return new Response<CreateShoeDto>(entity, "Başarıyla eklendi");
        }

        public async Task<Response> TDeleteAsync(int id)
        {
            await _shoeDal.DeleteAsync(id);
            await _uow.CommitAsync();
            return new Response("Başarıyla silindi", ResponseType.Success);
        }

        public Response<IQueryable<ResultShoeDto>> TGetByFilter(Expression<Func<Shoe, bool>> filter)
        {
            var values = _shoeDal.GetByFilter(filter);
            var resultShoe = ObjectMapper.mapper.Map<List<ResultShoeDto>>(values).AsQueryable();
            if (values == null)
            {
                return new Response<IQueryable<ResultShoeDto>>(resultShoe, "Veri bulunamadı");
            }
            return new Response<IQueryable<ResultShoeDto>>(resultShoe);
        }

        public async Task<Response<ResultShoeDto>> TGetByIdAsync(int id)
        {
            var value = await _shoeDal.GetByIdAsync(id);
            if (value == null)
            {
                return new Response<ResultShoeDto>("Veri getirilemedi", ResponseType.Fail);
            }
            var resultShoe = ObjectMapper.mapper.Map<ResultShoeDto>(value);
            return new Response<ResultShoeDto>(resultShoe);
        }

        public async Task<Response<IEnumerable<ResultShoeDto>>> TGetListAsync()
        {
            var value = await _shoeDal.GetListAsync();
            var resultShoe = ObjectMapper.mapper.Map<List<ResultShoeDto>>(value);
            return new Response<IEnumerable<ResultShoeDto>>(resultShoe);

        }

        public Response<UpdateShoeDto> TUpdate(UpdateShoeDto entity)
        {
            var validate = _updateShoeValidator.Validate(entity);
            if (!validate.IsValid)
            {
                return new Response<UpdateShoeDto>(entity, validate.CustomValidationError());
            }
            var updateShoe = ObjectMapper.mapper.Map<Shoe>(entity);
            _shoeDal.Update(updateShoe);
            _uow.Commit();
            return new Response<UpdateShoeDto>(entity, "Başarıyla güncellendi");
        }
    }
}
