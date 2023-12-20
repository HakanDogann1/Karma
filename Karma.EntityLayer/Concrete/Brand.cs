using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
    public class Brand:BaseEntity
    {
        public string BrandName { get; set; }
        public int Piece { get; set; }
        public string ImageUrl { get; set; }
    }
}
