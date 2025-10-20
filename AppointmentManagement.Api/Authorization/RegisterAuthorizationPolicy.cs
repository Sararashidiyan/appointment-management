using System.Security;
using AppointmentManagement.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentManagement.Api.Authorization
{
    public static class RegisterAuthorizationPolicy
    {
        public static IServiceCollection AddAuthorizationPolicy(this IServiceCollection services)
        {
            var permissions = Enum.GetNames<DoctorPermissionEnum>().ToList();
            permissions.AddRange([.. Enum.GetNames<PatientPermissionEnum>()]);
            permissions.AddRange([.. Enum.GetNames<PanelPermissionEnum>()]);
            services.AddAuthorization(options =>
            {
                foreach (var permission in permissions)
                {
                    options.AddPolicy($"Permission:{permission}", policy =>
                        policy.Requirements.Add(new PermissionRequirement(permission)));
                }
            });

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            return services;
        }
    }
}
