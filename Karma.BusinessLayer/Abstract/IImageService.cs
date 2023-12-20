using Karma.DtoLayer.Dtos.ImageDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
	public interface IImageService:IGenericService<Image,ResultImageDto,CreateImageDto,UpdateImageDto>
	{
	}
}
