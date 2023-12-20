﻿using Karma.EntityLayer.Concrete;

namespace Karma.API.Models.NewCollectionModel
{
	public class CreateNewCollectionViewModel
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int? ShoeId { get; set; }
		public Shoe Shoe { get; set; }
	}
}
