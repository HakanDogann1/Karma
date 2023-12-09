using Karma.CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface IGenericService<TEntity,TResult,TCreate,TUpdt> 
        where TResult : class
        where TCreate : class
        where TUpdt : class
        where TEntity : class
    {
        Task<Response<TResult>> TGetByIdAsync(int id);
        Task<Response<IEnumerable<TResult>>> TGetListAsync();
        Response<IQueryable<TResult>> TGetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<Response<TCreate>> TAddAsync(TCreate entity);
        Task<Response> TDeleteAsync(int id);
        Response<TUpdt> TUpdate(TUpdt entity);
    }
}
