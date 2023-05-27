using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ShoeDiscount
    {
        public int ShoeDiscountID { get; set; }
        public string ShoeDiscountModel { get; set; }
        public double ShoeDiscountPrice { get; set; }
        public double ShoeDiscountNewPrice { get; set; }
        public string ShoeDiscountAvailability { get; set; }
        public string ShoeDiscountDescription { get; set; }
        public string ShoeDiscountImageUrl { get; set; }


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
