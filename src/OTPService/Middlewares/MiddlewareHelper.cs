using Microsoft.AspNetCore.Builder;

namespace OTP.Service.Middlewares
{
    public static class MiddlewareHelper
    {
        public static IApplicationBuilder UseClientSecretMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ClientSecretMiddleware>();
        }
    }
}
