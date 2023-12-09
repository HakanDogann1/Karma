using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Karma.PresentetionLayer.Extensions
{
    public static class CustomExtensions
    {
        public static void CustomConigurationExtensions(this IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}
