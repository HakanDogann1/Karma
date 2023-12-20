using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DtoLayer.Dtos.ServiceDto
{
	public class UpdateServiceDto : BaseDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
	}
}
