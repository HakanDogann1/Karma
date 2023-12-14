using Karma.BusinessLayer.Abstract;
using Karma.CommonLayer;
using Karma.DataAccessLayer.Abstract;
using Karma.DtoLayer.Dtos.TasteShoeDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Concrete
{
    public class TasteShoeManager : ITasteShoeService
    {
        private readonly ITasteShoeDal _tasteShoeDal;

        public TasteShoeManager(ITasteShoeDal tasteShoeDal)
        {
            _tasteShoeDal = tasteShoeDal;
        }

        public Task<Response<CreateTasteShoeDto>> TAddAsync(CreateTasteShoeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> TDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Response<IQueryable<ResultTasteShoeDto>> TGetByFilter(Expression<Func<TasteShoe, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultTasteShoeDto>> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ResultTasteShoeDto>>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Response<UpdateTasteShoeDto> TUpdate(UpdateTasteShoeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
