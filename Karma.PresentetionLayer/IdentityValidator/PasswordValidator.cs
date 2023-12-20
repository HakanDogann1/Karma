using Karma.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Karma.PresentetionLayer.IdentityValidator
{
	public class PasswordValidator : IPasswordValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
		{
			var errorList = new List<IdentityError>();

			var hasPasswordStartsWithUserName = password.StartsWith(user.UserName);
			if(hasPasswordStartsWithUserName)
			{
				errorList.Add(new IdentityError() { Code = "PasswordStartsWithUserName", Description = "Şifre kullanıcı adını içeremez." });
			}
			if(errorList.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errorList.ToArray()));
			}
			return Task.FromResult(IdentityResult.Success);

		}
	}
}
