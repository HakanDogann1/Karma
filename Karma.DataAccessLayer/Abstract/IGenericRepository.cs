using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
        IQueryable<T> GetByFilter(Expression<Func<T,bool>> filter);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        T Update(T entity);
    }
}
