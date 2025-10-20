using AppointmentManagement.Domain.Authorization;

namespace AppointmentManagement.Infrastructure
{ 
    public static class StaticRolePermissions
    {
        public static readonly Dictionary<string, List<string>> PermissionsByRole = new()
        {
              { "Patient", Enum.GetValues(typeof(PatientPermissionEnum))
                      .Cast<PatientPermissionEnum>()
                      .Select(p => p.ToString())
                      .ToList() },
              { "Doctor", Enum.GetValues(typeof(DoctorPermissionEnum))
                      .Cast<DoctorPermissionEnum>()
                      .Select(p => p.ToString())
                      .ToList() }
        };
    }
}
