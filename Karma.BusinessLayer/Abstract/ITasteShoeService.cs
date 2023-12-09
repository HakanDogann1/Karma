using Karma.DtoLayer.Dtos.TasteShoeDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface ITasteShoeService:IGenericService<TasteShoe,ResultTasteShoeDto,CreateTasteShoeDto,UpdateTasteShoeDto>
    {
    }
}
