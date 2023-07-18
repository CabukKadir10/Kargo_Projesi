using Entity.Concrete;
using Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Services.Abstract;
using System.Net;
using NotFound = Entity.Exceptions.NotFound;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //status cod alıyoruz default olarak 500 alıyoruz
                    context.Response.ContentType = "application/json"; //dönüş tipini json olarak alıyoruz.

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFound => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Yanlış giden şeyler var: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails() {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
