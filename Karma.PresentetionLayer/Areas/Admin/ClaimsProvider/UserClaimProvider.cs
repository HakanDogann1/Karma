using Karma.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Karma.PresentetionLayer.Areas.Admin.ClaimsProvider
{
    public class UserClaimProvider : IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public UserClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;

            var currentUser = await _userManager.FindByNameAsync(identity!.Name);

            if(currentUser == null)
            {
                return principal;
            }
            if (string.IsNullOrEmpty(currentUser.City))
            {
                return principal;
            }
            if (identity.HasClaim(x => x.Type != "city"))
            {
                Claim claim = new Claim("city", currentUser.City);
                identity.AddClaim(claim);
            }
            return principal;
        }
    }
}

