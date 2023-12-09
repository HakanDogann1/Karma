using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
    public class Color:BaseEntity
    {
        public string ColorName { get; set; }
        public int Piece { get; set; }
    }
}
