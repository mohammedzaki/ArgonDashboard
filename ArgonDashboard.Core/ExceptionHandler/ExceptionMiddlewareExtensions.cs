using System;
using Microsoft.AspNetCore.Builder;

namespace ArgonDashboard.Core.ExceptionHandler
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseArgonCoreAPIExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
