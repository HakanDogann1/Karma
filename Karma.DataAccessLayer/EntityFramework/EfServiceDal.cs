using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.Concrete;
using Karma.DataAccessLayer.Context;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccessLayer.EntityFramework
{
	public class EfServiceDal : GenericRepository<Service>, IServiceDal
	{
		public EfServiceDal(KarmaDbContext context) : base(context)
		{
		}
	}
}
