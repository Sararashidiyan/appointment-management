using AppointmentManagement.Domain.SystemUsers;

namespace AppointmentManagement.Domain.Test
{
    public class PasswordHelperTests
    {
        [Fact]
        public void CreatePasswordHash_ShouldGenerateValidHashAndSalt()
        {
            // Arrange
            string password = "SecurePassword123";

            // Act
            PasswordHelper.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            // Assert
            Assert.NotNull(hash);
            Assert.NotNull(salt);
            Assert.True(hash.Length > 0);
            Assert.True(salt.Length > 0);

            // Verify
            bool isValid = PasswordHelper.VerifyPassword(password, hash, salt);
            Assert.True(isValid);
        }

        [Fact]
        public void VerifyPassword_ShouldFailWithWrongPassword()
        {
            // Arrange
            string correctPassword = "SecurePassword123";
            string wrongPassword = "WrongPassword456";

            PasswordHelper.CreatePasswordHash(correctPassword, out byte[] hash, out byte[] salt);

            // Act
            bool isValid = PasswordHelper.VerifyPassword(wrongPassword, hash, salt);

            // Assert
            Assert.False(isValid);
        }
    }

}
