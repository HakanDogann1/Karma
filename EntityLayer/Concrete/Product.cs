using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductModel { get; set; }
        public double ProductPrice{ get; set; }
        public string ProductAvailability{ get; set; }
        public string ProductDescription{ get; set; }
        public string ProductImageUrl{ get; set; }

        public int ShoeBrandID { get; set; }
        public ShoeBrand ShoeBrand { get; set; }

        public int ShoeCategoryID { get; set; }
        public ShoeCategory ShoeCategory { get; set; }

        public int ShoeColorID { get; set; }
        public ShoeColor ShoeColor { get; set; }

        public int ShoePriceID { get; set; }
        public ShoePrice ShoePrice { get; set; }
    }
}
