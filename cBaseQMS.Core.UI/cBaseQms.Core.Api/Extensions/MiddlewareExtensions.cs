using cBaseQms.Core.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cBaseQms.Core.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMessageHandlerMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MessageHandlerMiddleWare>();
        }
        public static IApplicationBuilder UseJsonExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JsonExceptionMiddleware>();
        }
    }
}
