using Karma.DtoLayer.Dtos.BasketDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket,ResultBasketDto,CreateBasketDto,UpdateBasketDto>
    {
    }
}
