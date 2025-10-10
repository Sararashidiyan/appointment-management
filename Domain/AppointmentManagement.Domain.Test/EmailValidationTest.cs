using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Exceptions;
using AppointmentManagement.Domain.Users;

namespace AppointmentManagement.Domain.Test
{
    public class EmailValidationTest
    {
        [Fact]
        public void ValidEmail_ShouldCreateSuccessfully()
        {
            var email = "sara@gmail.com";
            var emailObj = new Email(email);
            Assert.Equal(email, emailObj.Value);
        }
        [Fact]
        public void InValidEmail_ShouldThrowException()
        {
            //Arrange
            var email = "saragmail.com";
            // Act & Assert
            var ex = Assert.Throws<InvalidEmailException>(() => new Email(email));
            Assert.Equal("Email is invalid.", ex.Message);
        }
    }
}
