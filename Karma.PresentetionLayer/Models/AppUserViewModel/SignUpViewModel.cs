using System.ComponentModel.DataAnnotations;

namespace Karma.PresentetionLayer.Models.AppUserViewModel
{
    public class SignUpViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Name),ErrorMessage ="Şifre ile şifre tekrar alanı aynı olmalıdır.")]
        public string PasswordConfirm { get; set; }
    }
}
