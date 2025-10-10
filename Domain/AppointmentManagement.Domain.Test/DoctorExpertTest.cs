using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManagement.Domain.Appointments.AppointmentStates;
using AppointmentManagement.Domain.Appointments;
using AppointmentManagement.Domain.Doctors.DoctorExperts;


namespace AppointmentManagement.Domain.Test
{
    public class DoctorExpertTest
    {
       
        [Fact]
        public void create_rate_should_create_doctorExpertRate_properly()
        {
            //Arrange
            var rate = 1;
            var email = "sara@gmail.com";
            //Act
            var doctorExpertRate = new DoctorExpertRate(email, rate);
            //Assert
            Assert.Equal(doctorExpertRate.Rate, rate);
            Assert.Equal(doctorExpertRate.Email, email);
        }
        [Fact]
        public void create_review_should_create_doctorExpertReview_properly()
        {
            //Arrange
            var comment = "hi";
            var email = "sara@gmail.com";
            //Act
            var doctorExpertReview = new DoctorExpertReview(email, comment);
            //Assert
            Assert.Equal(doctorExpertReview.Comment, comment);
            Assert.Equal(doctorExpertReview.Email, email);
        }
        [Fact]
        public void doctorExpertRate_should_add_to_doctorExpertRates_properly()
        {
            //Arrange
            var doctorId = 1;
            var expertId = 1;
            var rate = 1;
            var email = "sara@gmail.com";
            //Act
            var doctorExpert = new DoctorExpert(expertId);
            var doctorExpertRate = new DoctorExpertRate(email, rate);
            doctorExpert.AddRate(doctorExpertRate);
            //Assert
            Assert.Equal(doctorExpert.DoctorRates,new List<DoctorExpertRate> { doctorExpertRate });
            Assert.Single(doctorExpert.DoctorRates);
        }
        [Fact]
        public void doctorExpertReview_should_add_to_doctorExpertReviews_properly()
        {
            //Arrange
            var doctorId = 1;
            var expertId = 1;
            var comment = "hi";
            var email = "sara@gmail.com";
            //Act
            var doctorExpert = new DoctorExpert(expertId);
            var doctorExpertReview = new DoctorExpertReview(email, comment);
            doctorExpert.AddReview(doctorExpertReview);
            //Assert
            Assert.Equal(doctorExpert.DoctorExpertReviews, new List<DoctorExpertReview> { doctorExpertReview });
            Assert.Single(doctorExpert.DoctorExpertReviews);
        }

    }
}
