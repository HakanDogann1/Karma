using Karma.DataAccessLayer.Context;
using Karma.EntityLayer.Concrete;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Karma.PresentetionLayer.Extensions
{
    public static class CustomExtensions
    {
        public static void CustomConigurationExtensions(this IServiceCollection services)
        {
			
			services.AddHttpClient();
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<KarmaDbContext>();
		}
    }
}
