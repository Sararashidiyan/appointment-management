using AppointmentManagement.Domain.SystemUsers;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Test
{
    public class SystemUserTest
    {
        [Fact]
        public void create_should_create_systemUser_properly()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var FullName = $"{firstName} {lastName}";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Admin;
            var password = "123456";
            //Act
            var systemUser=new SystemUser(firstName, lastName, email,mobile, role, password);
            //Assert
            Assert.Equal(firstName, systemUser.FirstName);
            Assert.Equal(lastName, systemUser.LastName);
            Assert.Equal(FullName, systemUser.FullName);
            Assert.Equal(role, systemUser.Role);
            Assert.Equal(mobile, systemUser.Mobile);
            Assert.Equal(email, systemUser.Email);
            Assert.False(systemUser.IsSupperAdmin);

        }
        [Fact]
        public void create_supper_admin_should_create_supper_admin_properly()
        {
            //Arrange
            var firstName = "سارا";
            var lastName = "رشیدی یان";
            var FullName = $"{firstName} {lastName}";
            var email = new Email("sara@gmail.com");
            var mobile = new Mobile("09126717325");
            var role = RoleType.Admin;
            //Act
            var systemUser=SystemUser.CraeteSupperAdmin(firstName, lastName, email,mobile);
            //Assert
            Assert.Equal(firstName, systemUser.FirstName);
            Assert.Equal(lastName, systemUser.LastName);
            Assert.Equal(FullName, systemUser.FullName);
            Assert.Equal(role, systemUser.Role);
            Assert.Equal(mobile, systemUser.Mobile);
            Assert.Equal(email, systemUser.Email);
            Assert.True(systemUser.IsSupperAdmin);
        }
    }

}
