

using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections;

namespace WebAPI.Extensions
{
    public static class ExtensionConfiguration
    {
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            var secretKey = _tokenOptions.SecurityKey;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = _tokenOptions.Issuer,
                    ValidAudience = _tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey)
                };
            });
        }
    }

}
