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
    public class ShoeColorManager : IShoeColorService
    {
        private readonly IShoeColorDal _shoeColorDal;

        public ShoeColorManager(IShoeColorDal shoeColorDal)
        {
            _shoeColorDal = shoeColorDal;
        }

        public void TAdd(ShoeColor entity)
        {
            _shoeColorDal.Add(entity);
        }

        public void TDelete(ShoeColor entity)
        {
            _shoeColorDal.Delete(entity);
        }

        public ShoeColor TGetById(int id)
        {
           return _shoeColorDal.GetById(id);
        }

        public List<ShoeColor> TGetList()
        {
            return _shoeColorDal.GetList();
        }

        public void TUpdate(ShoeColor entity)
        {
            _shoeColorDal.Update(entity);
        }
    }
}
