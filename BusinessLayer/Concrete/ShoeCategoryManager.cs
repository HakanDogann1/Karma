using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ShoeCategoryManager : IShoeCategoryService
    {
        private readonly IShoeCategoryDal _shoeCategoryDal;

        public ShoeCategoryManager(IShoeCategoryDal shoeCategoryDal)
        {
            _shoeCategoryDal = shoeCategoryDal;
        }

        public void TAdd(ShoeCategory entity)
        {
         _shoeCategoryDal.Add(entity);
        }

        public void TDelete(ShoeCategory entity)
        {
            _shoeCategoryDal.Delete(entity);
        }

        public ShoeCategory TGetById(int id)
        {
            return _shoeCategoryDal.GetById(id);
        }

        public List<ShoeCategory> TGetList()
        {
           return _shoeCategoryDal.GetList();
        }

        public void TUpdate(ShoeCategory entity)
        {
            _shoeCategoryDal.Update(entity);
        }
    }
}
