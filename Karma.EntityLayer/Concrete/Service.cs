using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
	public class Service:BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
