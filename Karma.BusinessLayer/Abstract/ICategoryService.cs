using Karma.DtoLayer.Dtos.CategoryDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category,ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto>
    {
    }
}
