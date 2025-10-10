using AppointmentManagement.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AppointmentManagement.Api.Extensions
{
    public static class RegisterAuthentication
    {
        public static IServiceCollection AddJwtAuthenticationService(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSettingsSection = configuration.GetSection("JwtSettings");
            var jwtSetting = jwtSettingsSection?.Get<JwtSettings>();
            if (jwtSetting == null)
            {
                //logger.LogInformation("jwt feature is not available.");
                return service;
            }
            service.Configure<JwtSettings>(jwtSettingsSection);
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
                };
            });
            return service;
        }
    }

}
