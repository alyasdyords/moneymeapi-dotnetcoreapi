using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyme_api
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (context.Request.Headers.ContainsKey(CorsConstants.Origin))
            //{
                context.Response.Headers.Add("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);
                context.Response.Headers.Add("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS,HEAD,PATCH");
                context.Response.Headers.Add("Access-Control-Allow-Headers", context.Request.Headers["Access-Control-Request-Headers"]);
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

                if (context.Request.Method.Equals("OPTIONS"))
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    return;
                }
            //}

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
}
