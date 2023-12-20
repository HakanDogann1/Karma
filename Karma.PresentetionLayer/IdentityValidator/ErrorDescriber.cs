using Microsoft.AspNetCore.Identity;

namespace Karma.PresentetionLayer.IdentityValidator
{
	public class ErrorDescriber:IdentityErrorDescriber
	{
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError()
			{
				Code = "DuplicateEmail",
				Description = $"{email} ile daha önce bir hesap oluşturulmuş."
			};
		}

		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "DuplicateUserName",
				Description = $"{userName} ile daha öne bir hesap oluşturulmuş. "
			};
		}

		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError()
			{
				Code = "InvalidEmail",
				Description = "Geçersiz email adresi"
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifre küçük harf içermelidir."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifre büyük karakter içermelidir."
			};
		}

		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = "Şifre küçük karakter içermelidir."
			};
		}
	}
}
