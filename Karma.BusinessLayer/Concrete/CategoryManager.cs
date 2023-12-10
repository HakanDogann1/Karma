using Karma.BusinessLayer.Abstract;
using Karma.CommonLayer;
using Karma.DtoLayer.Dtos.CategoryDto;
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
        public Task<Response<CreateCategoryDto>> TAddAsync(CreateCategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> TDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Response<IQueryable<ResultCategoryDto>> TGetByFilter(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultCategoryDto>> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ResultCategoryDto>>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Response<UpdateCategoryDto> TUpdate(UpdateCategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
