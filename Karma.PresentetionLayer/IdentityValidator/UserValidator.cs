using Karma.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Karma.PresentetionLayer.IdentityValdiator
{
	public class UserValidator : IUserValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
		{
			var errorList = new List<IdentityError>();
			if (user.Email.StartsWith(user.UserName))
			{
				errorList.Add(new IdentityError() { Code = "EmailStartsWithUsername", Description = "Email ile kullanıcı adı aynı olmamalıdır." });
			}
			var isNumericUserName= int.TryParse(user.UserName[0].ToString(), out _);
			if (isNumericUserName)
			{
				errorList.Add(new IdentityError() { Code = "UserNameStartsWithNumeric", Description = "Kullanıcı adı sayısal bir ifade ile başlayamaz." });
			}
			var isNumericmEmail = int.TryParse(user.Email[0].ToString(), out _);
			if (isNumericmEmail)
			{
				errorList.Add(new IdentityError() { Code = "EmailStartsWithNumeric", Description = "Email adresi sayısal ifade ile başlayamaz." });
			}

			if (errorList.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errorList.ToArray()));
			}

			return Task.FromResult(IdentityResult.Success);
		}
	}
}
