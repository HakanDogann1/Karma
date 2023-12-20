using System.ComponentModel.DataAnnotations;

namespace Karma.PresentetionLayer.Models.AppUserViewModel
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Email alanı boş geçilemez")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]
		public string? UserName { get; set; }
		[Required(ErrorMessage = "Telefon numarası alanı boş geçilemez")]
		public string? PhoneNumber { get; set; }
		[Required(ErrorMessage = "Şifre alanı boş geçilemez")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
		[Compare(nameof(Password),ErrorMessage ="Şifre ile şifre tekrar alanı aynı olmalıdır.")]
        public string PasswordConfirm { get; set; }
    }
}
