using Karma.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.EntityLayer.Concrete
{
    public class Shoe:BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }

        public string Description { get; set; }
        public int Stock { get; set; }
        
        public int Width{ get; set; }
        public int Height{ get; set; }
        public int Depth{ get; set; }
        public int NumberId { get; set; }
        public Number Number { get; set; }

		public decimal Price { get; set; }
		public decimal? NewPrice { get; set; }

        public List<NewCollection> NewCollections { get; set; }
        public List<Image> Images { get; set; }
    }
}
