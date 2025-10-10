using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Test
{
    public class MobileValidationTest
    {
        [Fact]
        public void ValidMobile_ShouldCreateSuccessfully()
        {
            var mobile = "09126717325";
            var mobileObj = new Mobile(mobile);
            Assert.Equal(mobile, mobileObj.Value);
        }
        [Fact]
        public void InValidMobile_ShouldThrowException()
        {
            //Arrange
            var mobile = "091267174325";
            // Act & Assert
            var ex = Assert.Throws<InvalidMobileException>(() => new Mobile(mobile));
            Assert.Equal("Mobile is invalid.", ex.Message);
        }
    }
}
