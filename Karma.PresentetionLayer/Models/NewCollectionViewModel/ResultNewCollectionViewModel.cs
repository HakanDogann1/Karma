using Karma.EntityLayer.Concrete;

namespace Karma.PresentetionLayer.Models.NewCollectionViewModel
{
	public class ResultNewCollectionViewModel
	{
        public int Id { get; set; }
        public string? Title { get; set; }
		public string? Description { get; set; }
		public int? ShoeId { get; set; }
		public Shoe Shoe { get; set; }
	}
}
