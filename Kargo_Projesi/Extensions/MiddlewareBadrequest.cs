using Entity.Concrete;
using Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Abstract;

namespace WebApi.Extensions
{
    public static class MiddlewareBadrequest
    {
        public static void ConfigureExceptionHandler2(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        // Check if the status code is 400 (Bad Request)
                        if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                        {
                            logger.LogError($"Bad Request: {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Bad Request: " + contextFeature.Error.Message
                            }.ToString());
                        }
                        else
                        {
                            // For other errors, use the existing logic
                            context.Response.StatusCode = contextFeature.Error switch
                            {
                                NotFound => StatusCodes.Status404NotFound,
                                _ => StatusCodes.Status500InternalServerError
                            };

                            logger.LogError($"Something went wrong: {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}
