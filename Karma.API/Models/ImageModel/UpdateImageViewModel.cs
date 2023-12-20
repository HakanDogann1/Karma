using Karma.EntityLayer.Concrete;

namespace Karma.API.Models.ImageModel
{
	public class UpdateImageViewModel:BaseViewModel
	{
		public int ShoeId { get; set; }
		public Shoe Shoe { get; set; }

		public string? ImageUrl { get; set; }
	}
}
