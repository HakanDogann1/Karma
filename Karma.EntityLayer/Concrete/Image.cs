using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
	public class Image:BaseEntity
	{
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }

        public string ImageUrl { get; set; }
    }
}
