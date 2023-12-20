namespace Karma.API.Models.ContactModel
{
	public class UpdateContactViewModel:BaseViewModel
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Subject { get; set; }
		public string? Message { get; set; }
	}
}
