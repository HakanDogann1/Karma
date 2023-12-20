using System.ComponentModel.DataAnnotations;

namespace Karma.PresentetionLayer.Models.AppUserViewModel
{
	public class UserEditViewModel
	{
        public int Id { get; set; }
		[Required(ErrorMessage = "Ad alanı boş geçilemez")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Email alanı boş geçilemez")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]
		public string? UserName { get; set; }
		[Required(ErrorMessage = "Telefon numarası alanı boş geçilemez")]
		public string? PhoneNumber { get; set; }

        public FormFile? Image { get; set; }
        public string City { get; set; }

    }
}
