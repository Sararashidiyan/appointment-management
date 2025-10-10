using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace AppointmentManagement.Application
{
    public class CurrentUserService : ICurrentUserService
    {
        public long UserId { get; }
        public string FullName { get; }
        public string Role { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated == true)
            {
                UserId =Convert.ToInt64(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                FullName = user.FindFirst(ClaimTypes.Name)?.Value;
                Role = user.FindFirst(ClaimTypes.Role)?.Value;
            }
        }
    }
}
