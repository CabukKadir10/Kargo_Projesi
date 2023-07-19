using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Extensions
{
    public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        // Varsayılan işleyiciye erişim için
        private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new AuthorizationMiddlewareResultHandler();

        // HandleAsync metodunu uygulama
        public async Task HandleAsync(RequestDelegate requestDelegate, HttpContext httpContext, AuthorizationPolicy authorizationPolicy, PolicyAuthorizationResult policyAuthorizationResult)
        {
            // Eğer yetkilendirme başarısızsa
            if (!policyAuthorizationResult.Succeeded)
            {
                // Yanıt durum kodunu 403 olarak ayarla
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

                // Yanıt gövdesine JSON olarak hata mesajı yaz
                await httpContext.Response.WriteAsJsonAsync(new { message = "Yetkisiz erişim" });
            }
            else
            {
                // Eğer yetkilendirme başarılıysa, varsayılan işleyiciyi çağır
                await _defaultHandler.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);
            }
        }
    }
}
