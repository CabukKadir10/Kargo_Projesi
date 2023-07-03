using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } //hedef kitle
        public string Issuer { get; set; } //kim tarafından oluşturuluyor
        public int AccessTokenExpiration { get; set; } //süredir buda
        public string SecurityKey { get; set; } //token imzasında kullanılan güvenlik anahtarıdır.
    }
}
