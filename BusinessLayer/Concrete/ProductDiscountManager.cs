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
    public class ProductDiscountManager : IProductDiscountService
    {
        private readonly IProductDiscountDal _productDiscountDal;

        public ProductDiscountManager(IProductDiscountDal productDiscountDal)
        {
            _productDiscountDal = productDiscountDal;
        }

        public void TAdd(ProductDiscount entity)
        {
           _productDiscountDal.Add(entity);
        }

        public void TDelete(ProductDiscount entity)
        {
            _productDiscountDal.Delete(entity);
        }

        public ProductDiscount TGetById(int id)
        {
            return _productDiscountDal.GetById(id);
        }

        public List<ProductDiscount> TGetList()
        {
            return _productDiscountDal.GetList();
        }

        public void TUpdate(ProductDiscount entity)
        {
           _productDiscountDal.Update(entity);
        }
    }
}
