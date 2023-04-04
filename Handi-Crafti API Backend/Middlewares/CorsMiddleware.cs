using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Handi_Crafti_API_Backend.Middlewares
{
    public class CorsMiddleware
    {
    }
}



public class CorsMiddleware
{
    private readonly RequestDelegate _next;

    public CorsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        await _next(context);
    }
}

public static class CorsMiddlewareExtensions
{
    public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorsMiddleware>();
    }
}
