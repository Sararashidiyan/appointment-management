using AppointmentManagement.Domain.Patients;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Test
{
    public class PatientTest
    {
        [Fact]
        public void create_should_create_patient_properly()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var FullName = $"{firstName} {lastName}";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var nationalCode = new NationalCode("0017812984");
            var role = RoleType.Patient;
            //Act
            var patient = new Patient(firstName, lastName, email,mobile, nationalCode);
            //Assert
            Assert.Equal(firstName, patient.FirstName);
            Assert.Equal(lastName, patient.LastName);
            Assert.Equal(FullName, patient.FullName);
            Assert.Equal(role, patient.Role);
            Assert.Equal(mobile, patient.Mobile);
            Assert.Equal(email, patient.Email);
            Assert.Equal(nationalCode, patient.NationalCode);
        }
        [Fact]
        public void update_should_update_patient_properly()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var nationalCode = new NationalCode("0017812984");
            var patient = new Patient(firstName, lastName, email, mobile, nationalCode);
            //Act
            patient.Update(firstName, lastName, email, nationalCode);
            //Assert
            Assert.Equal(firstName, patient.FirstName);
            Assert.Equal(lastName, patient.LastName);
            Assert.Equal(email, patient.Email);
            Assert.Equal(nationalCode, patient.NationalCode);
        }
    }
}
