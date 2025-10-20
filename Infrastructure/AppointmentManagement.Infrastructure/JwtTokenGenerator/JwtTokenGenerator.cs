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
        public string GenerateDoctorToken(User user)
        {
            var permissions = StaticRolePermissions.PermissionsByRole["Doctor"];
            return GenerateToken(user,permissions);
        }

        public string GeneratePatientToken(User user)
        {
            var permissions = StaticRolePermissions.PermissionsByRole["Patient"];
            return GenerateToken(user, permissions);
        }

        private string GenerateToken(User user,List<string> permissions)
        {
            var expires = DateTime.UtcNow.AddMinutes(30);
            var claims =new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expires).ToUnixTimeSeconds().ToString()),
                new("expireAt", expires.ToString("o")) // ISO 8601 format for client
            };
            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }
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

        public string GenerateUserToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
