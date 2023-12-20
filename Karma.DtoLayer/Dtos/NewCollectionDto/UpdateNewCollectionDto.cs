using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.NewCollectionDto
{
	public class UpdateNewCollectionDto : BaseDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public int ShoeId { get; set; }
		public Shoe Shoe { get; set; }
	}
}
