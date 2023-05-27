using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericRepositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            Context context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context context = new Context();
            context.Remove(entity);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            Context context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            Context context = new Context();
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            Context context = new Context();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
