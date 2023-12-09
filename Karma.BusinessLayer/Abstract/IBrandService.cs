using Karma.DtoLayer.Dtos.BrandDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface IBrandService:IGenericService<Brand,ResultBrandDto,CreateBrandDto,UpdateBrandDto>
    {
    }
}
