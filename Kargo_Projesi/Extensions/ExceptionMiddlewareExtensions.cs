using Entity.Concrete;
using Entity.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Services.Abstract;
using System.ComponentModel.DataAnnotations;
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
                    context.Response.ContentType = "application/json"; //dönüş tipini json olarak alıyoruz.

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            BadRequestException => StatusCodes.Status400BadRequest,
                            UnauthorizedAccessExceptionn => StatusCodes.Status401Unauthorized,
                            ForbiddenException => StatusCodes.Status403Forbidden,
                            NotFound => StatusCodes.Status404NotFound,
                            //InternalServerErrorException => StatusCodes.Status500InternalServerError,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        var statusCode = context.Response.StatusCode;

                        var message = statusCode switch
                        {
                            StatusCodes.Status400BadRequest => "Geçersiz istek: " + contextFeature.Error.Message,
                            StatusCodes.Status401Unauthorized => "Yetkisiz erişim: " + contextFeature.Error.Message,
                            StatusCodes.Status403Forbidden => "Yasaklanmış erişim: " + contextFeature.Error.Message,
                            StatusCodes.Status404NotFound => "Kaynak bulunamadı: " + contextFeature.Error.Message,
                            StatusCodes.Status500InternalServerError => "Sunucu içi hata: " + contextFeature.Error.Message,
                            StatusCodes.Status501NotImplemented => "Uygulanmamış işlem: " + contextFeature.Error.Message,
                            _ => "Beklenmedik bir hata oluştu: " + contextFeature.Error.Message
                        };

                        await context.Response.WriteAsJsonAsync(new { message = message });
                    }
                });
            });
        }
    }
}
