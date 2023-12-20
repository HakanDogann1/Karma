using Karma.DataAccessLayer.Context;
using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Areas.Admin.ClaimsProvider;
using Karma.PresentetionLayer.IdentityValdiator;
using Karma.PresentetionLayer.IdentityValidator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Karma.PresentetionLayer.Extensions
{
    public static class CustomExtensions
    {
        public static void CustomConigurationExtensions(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<KarmaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("useSql"));
            });
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
			services.AddHttpClient();
            services.AddScoped<IClaimsTransformation, UserClaimProvider>();
			services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(5);
            }).AddUserValidator<UserValidator>().AddPasswordValidator<PasswordValidator>().AddEntityFrameworkStores<KarmaDbContext>().AddErrorDescriber<ErrorDescriber>();

            services.ConfigureApplicationCookie(opt =>
            {
                var cookie = new CookieBuilder();
                opt.AccessDeniedPath =new PathString("/AccessDenied/Index/");
                opt.LoginPath = new PathString("/SignIn/Index/");
                opt.LogoutPath = new PathString("/SignIn/SignOut/");

                opt.ExpireTimeSpan= TimeSpan.FromDays(60);
                opt.SlidingExpiration = true;

                cookie.Name = "KarmaCookie";
                cookie.SameSite = SameSiteMode.None;
                cookie.IsEssential = true;
                cookie.HttpOnly = true;
                opt.Cookie = cookie;
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("KarabükPolicy", x =>
                {
                    x.RequireClaim("city", "Karabük");
                });
            });
		}
    }
}
