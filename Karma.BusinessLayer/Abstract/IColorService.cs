using Karma.DataAccessLayer.Abstract;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface IColorService:IGenericService<Color,ResultColorDto,CreateColorDto,UpdateColorDto>
    {
    }
}
