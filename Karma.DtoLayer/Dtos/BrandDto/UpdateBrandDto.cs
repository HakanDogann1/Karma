using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.BrandDto
{
    public class UpdateBrandDto:BaseDto
    {
        public string BrandName { get; set; }
        public int Piece { get; set; }
    }
}
