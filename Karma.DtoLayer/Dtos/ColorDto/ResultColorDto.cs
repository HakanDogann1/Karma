using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.ColorDto
{
    public class ResultColorDto:BaseDto
    {
        public string ColorName { get; set; }
        public int Piece { get; set; }
    }
}
