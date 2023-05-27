using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeaderDal : GenericRepository<Header>, IHeaderDal
    {
        public Header GetByHeader(int id)
        {
            Context context = new Context();
            return context.Headers.Where(x=>x.HeaderID == id).FirstOrDefault();
        }
    }
}
