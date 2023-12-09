using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
    public class Basket:BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int Piece { get; set; }
        public bool Status { get; set; }
    }
}
