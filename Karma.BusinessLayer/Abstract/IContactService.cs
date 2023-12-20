using Karma.DtoLayer.Dtos.ContactDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
	public interface IContactService:IGenericService<Contact,ResultContactDto,CreateContactDto,UpdateContactDto>
	{
	}
}
