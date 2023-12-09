using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
    public class Comment:BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
        public int? ParentCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Star { get; set; }
    }
}
