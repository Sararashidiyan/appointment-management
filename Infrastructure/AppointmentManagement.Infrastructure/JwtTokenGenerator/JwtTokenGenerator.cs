using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.JwtTokenGenerator;
using AppointmentManagement.Domain.Users;
using AppointmentManagement.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AppointmentManagement.Infrastructure.JwtTokenGenerator
{
    public class JwtTokenGenerator(IOptions<JwtSettings> setting) : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var expires = DateTime.UtcNow.AddMinutes(30);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expires).ToUnixTimeSeconds().ToString()),
                new Claim("expireAt", expires.ToString("o")) // ISO 8601 format for client
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.Value.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: setting.Value.Issuer,
                audience: setting.Value.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
