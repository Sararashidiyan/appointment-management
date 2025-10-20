using AppointmentManagement.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentManagement.Api.Authorization
{
    public class PanelPermissionAttribute : AuthorizeAttribute
    {
        public PanelPermissionAttribute(PanelPermissionEnum permission)
        {
            Policy = $"Permission:{permission.ToString()}";
        }
    }
    public class DoctorPermissionAttribute : AuthorizeAttribute
    {
        public DoctorPermissionAttribute(DoctorPermissionEnum permission)
        {
            Policy = $"Permission:{permission.ToString()}";
        }
    }
    public class PatientPermissionAttribute : AuthorizeAttribute
    {
        public PatientPermissionAttribute(PatientPermissionEnum permission)
        {
            Policy = $"Permission:{permission.ToString()}";
        }
    }

}
