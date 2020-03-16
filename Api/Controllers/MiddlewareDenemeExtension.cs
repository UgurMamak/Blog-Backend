using Microsoft.AspNetCore.Builder;

namespace Api.Controllers
{
    public static class DemoMiddlewareExtensions
    {
      
        public static IApplicationBuilder UseMiddlewareDenemeExtensions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareDeneme>();
        }
    }
}