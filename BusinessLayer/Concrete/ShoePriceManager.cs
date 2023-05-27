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
    public class ShoePriceManager : IShoePriceService
    {
        private readonly IShoePriceDal _shoePriceDal;

        public ShoePriceManager(IShoePriceDal shoePriceDal)
        {
            _shoePriceDal = shoePriceDal;
        }

        public void TAdd(ShoePrice entity)
        {
            _shoePriceDal.Add(entity);
        }

        public void TDelete(ShoePrice entity)
        {
            _shoePriceDal.Delete(entity);
        }

        public ShoePrice TGetById(int id)
        {
           return _shoePriceDal.GetById(id);
        }

        public List<ShoePrice> TGetList()
        {
            return _shoePriceDal.GetList();
        }

        public void TUpdate(ShoePrice entity)
        {
            _shoePriceDal.Update(entity);
        }
    }
}
