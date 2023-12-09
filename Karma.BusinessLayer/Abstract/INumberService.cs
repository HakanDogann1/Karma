using Karma.DtoLayer.Dtos.NumberDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface INumberService:IGenericService<Number,ResultNumberDto,CreateNumberDto,UpdateNumberDto>
    {
    }
}
