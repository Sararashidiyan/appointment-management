using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.Experts.DTOs;
using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Application.Mappers
{
    public  class ExpertMappers
    {
        public static ExpertDTO Map(Expert expert)
        {
            return new ExpertDTO()
            {
                LatinTitle=expert.LatinTitle,
                Title=expert.Title,
                Id=expert.Id,
            };
        }
        public static List<ExpertDTO>? Map(List<Expert> experts)
        {
            return experts?.Select(Map).ToList();
        }
    }
}
