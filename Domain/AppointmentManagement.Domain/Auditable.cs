using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain
{
    public abstract class Auditable
    {
        public DateTime CreatedAt { get; set; }
        public long CreatedUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedUserId { get; set; }
    }
}
