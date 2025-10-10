using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Test
{
    public class TestUserTest
    {
       
        [Fact]
        public void update_should_update_TestUser_properly()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Patient;
            var testUser = new TestUser(firstName, lastName, email, mobile, role);
            //Act
            testUser.Update(firstName, lastName, mobile);
            //Assert
            Assert.Equal(firstName, testUser.FirstName);
            Assert.Equal(lastName, testUser.LastName);
            Assert.Equal(mobile, testUser.Mobile);
        }
        [Fact]
        public void activate_should_active_TestUser()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Patient;
            var testUser = new TestUser(firstName, lastName, email, mobile, role);
            //Act
            testUser.Activate();
            //Assert
            Assert.True(testUser.IsActive);
        }
        [Fact]
        public void deactivate_should_deactive_TestUser()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Patient;
            var testUser = new TestUser(firstName, lastName, email, mobile, role);
            //Act
            testUser.Deactivate();
            //Assert
            Assert.False(testUser.IsActive);
        }
    }
}
