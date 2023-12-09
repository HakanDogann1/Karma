using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly KarmaDbContext _context;

        public GenericRepository(KarmaDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            _context.Remove(value!);
        }

        public  IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            var result = _context.Set<T>().Where(filter).AsQueryable();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
