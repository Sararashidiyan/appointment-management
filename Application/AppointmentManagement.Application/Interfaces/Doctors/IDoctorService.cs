using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Application.Interfaces.Doctors.DTOs;

namespace AppointmentManagement.Application.Interfaces.Doctors
{
    public interface IDoctorService
    {
        Task<DoctorDTO> GetById(long id);
        Task<List<DoctorDTO>> GetAll();
        Task Create(CreateDoctorCMD id);
        Task Modify(ModifyDoctorCMD id);
        Task Delete(long id);
        Task Activate(long id);
        Task Deactivate(long id);

    }
}
