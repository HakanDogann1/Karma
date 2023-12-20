using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.ImageDto
{
	public class ResultImageDto:BaseDto
	{
		public int ShoeId { get; set; }
		public Shoe Shoe { get; set; }

		public string ImageUrl { get; set; }
	}
}
