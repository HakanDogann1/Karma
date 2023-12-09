using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.CategoryDto
{
    public class ResultCategoryDto:BaseDto
    {
        public string CategoryName { get; set; }
        public int Piece { get; set; }
    }
}
