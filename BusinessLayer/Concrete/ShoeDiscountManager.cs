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
    public class ShoeDiscountManager : IShoeDiscountService
    {
        private readonly IShoeDiscountDal _shoeDiscountDal;

        public ShoeDiscountManager(IShoeDiscountDal shoeDiscountDal)
        {
            _shoeDiscountDal = shoeDiscountDal;
        }

        public void TAdd(ShoeDiscount entity)
        {
           _shoeDiscountDal.Add(entity);
        }

        public void TDelete(ShoeDiscount entity)
        {
            _shoeDiscountDal.Delete(entity);
        }

        public ShoeDiscount TGetById(int id)
        {
            return _shoeDiscountDal.GetById(id);
        }

        public List<ShoeDiscount> TGetList()
        {
            return _shoeDiscountDal.GetList();
        }

        public void TUpdate(ShoeDiscount entity)
        {
             _shoeDiscountDal.Update(entity);
        }
    }
}
