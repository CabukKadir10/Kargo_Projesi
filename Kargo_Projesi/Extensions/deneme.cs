using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace WebApi.Extensions
{
    public static class deneme
    {
        public static void ConfigureExceptionHandler2(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Sunucu içi hata: {contextFeature.Error}");

                        await context.Response.WriteAsJsonAsync(new { message = "Sunucu içi hata: " + contextFeature.Error.Message });
                    }
                });
            });
        }
    }
}
