using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeaderManager : IHeaderService
    {
        private readonly IHeaderDal _headerDal;

        public HeaderManager(IHeaderDal headerDal)
        {
            _headerDal = headerDal;
        }

        public void TAdd(Header entity)
        {
            _headerDal.Add(entity);
        }

        public void TDelete(Header entity)
        {
            _headerDal.Delete(entity);
        }

        public Header TGetByHeader(int id)
        {
            return _headerDal.GetByHeader(id);
        }

        public Header TGetById(int id)
        {
            return _headerDal.GetById(id);  
        }

        public List<Header> TGetList()
        {
            return _headerDal.GetList();
        }

        public void TUpdate(Header entity)
        {
           _headerDal.Update(entity);
        }
    }
}
