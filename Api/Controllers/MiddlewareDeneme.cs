using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Controllers
{
  public class MiddlewareDeneme
  {
    private readonly RequestDelegate _next;

    public MiddlewareDeneme(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      var key1 = httpContext.Request.Headers.Keys.Contains("Client-Key");
      var key2 = httpContext.Request.Headers.Keys.Contains("Device-Id");

      if (!key1)
      {
        httpContext.Response.StatusCode = 400;
        await httpContext.Response.WriteAsync(" Parametre eksik!");
        return;
      }
      else
      {
        //todo
      }
      await _next.Invoke(httpContext);
    }
  }
}
