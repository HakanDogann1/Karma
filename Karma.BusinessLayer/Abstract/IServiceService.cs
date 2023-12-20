using Karma.DtoLayer.Dtos.ServiceDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
	public interface IServiceService:IGenericService<Service,ResultServiceDto,CreateServiceDto,UpdateServiceDto>
	{
	}
}
