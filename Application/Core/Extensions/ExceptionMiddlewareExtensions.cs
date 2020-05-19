using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
          return  app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
