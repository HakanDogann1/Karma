using Karma.DtoLayer.Dtos.NewCollectionDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
	public interface INewCollectionService:IGenericService<NewCollection,ResultNewCollectionDto,CreateNewCollectionDto,UpdateNewCollectionDto>
	{
	}
}
