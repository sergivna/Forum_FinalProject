using WebAPI;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public sealed class TokenCookieConvertingMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenCookieConvertingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request
                .Cookies.TryGetValue(JwtHelper.JwtCookieName, out string jwtCookie))
            {
                context.Request.Headers.Add("Authorization", "Bearer " + jwtCookie);
            }

            await _next(context);
        }
    }
}
