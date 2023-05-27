using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ShoeBrandManager : IShoeBrandService
    {
        private readonly IShoeBrandDal _shoeBrandDal;

        public ShoeBrandManager(IShoeBrandDal shoeBrandDal)
        {
            _shoeBrandDal = shoeBrandDal;
        }

        public void TAdd(ShoeBrand entity)
        {
            _shoeBrandDal.Add(entity);
        }

        public void TDelete(ShoeBrand entity)
        {
            _shoeBrandDal.Delete(entity);
        }

        public ShoeBrand TGetById(int id)
        {
           return _shoeBrandDal.GetById(id);
        }

        public List<ShoeBrand> TGetList()
        {
            return _shoeBrandDal.GetList();
        }

        public void TUpdate(ShoeBrand entity)
        {
           _shoeBrandDal.Update(entity);
        }
    }
}
