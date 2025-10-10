using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Patients;

namespace AppointmentManagement.Domain.Test
{
    public class NationalCodeValidationTest
    {
        [Fact]
        public void ValidNationalCode_ShouldCreateSuccessfully()
        {
            var nationalCode = "0017812984";
            var nationalCodeObj = new NationalCode(nationalCode);
            Assert.Equal(nationalCode, nationalCodeObj.Value);
        }
        [Fact]
        public void InValidNationalCode_ShouldThrowException()
        {
            //Arrange
            var nationalCode = "001781298888";
            // Act & Assert
            var ex = Assert.Throws<InvalidNationalCodeException>(() => new NationalCode(nationalCode));
            Assert.Equal("NationalCode is invalid.", ex.Message);
        }
    }
}
