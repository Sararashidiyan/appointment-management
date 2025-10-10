using AppointmentManagement.Domain.Experts;

namespace AppointmentManagement.Domain.Test
{
    public class ExpertTest
    {
        [Fact]
        public void create_should_create_expert_properly()
        {
            //Arrange
            var title = "متخصص قلب";
            var latinTitle = "heart";
            //Act
            var expert=new Expert(title, latinTitle);
            //Assert
            Assert.Equal(title, expert.Title);
            Assert.Equal(latinTitle, expert.LatinTitle);
        }
        [Fact]
        public void update_should_update_expert_properly()
        {
            //Arrange
            var title = "متخصص قلب";
            var latinTitle = "heart";
            var expert = new Expert(title, latinTitle);
            //Act
            expert.Update(title, latinTitle);
            //Assert
            Assert.Equal(title, expert.Title);
            Assert.Equal(latinTitle, expert.LatinTitle);
        }
        [Fact]
        public void activate_should_active_expert()
        {
            //Arrange
            var title = "متخصص قلب";
            var latinTitle = "heart";
            var expert = new Expert(title, latinTitle);
            //Act
            expert.Activate();
            //Assert
            Assert.True(expert.IsActive);
        }
        [Fact]
        public void deactivate_should_deactive_expert()
        {
            //Arrange
            var title = "متخصص قلب";
            var latinTitle = "heart";
            var expert = new Expert(title, latinTitle);
            //Act
            expert.Deactivate();
            //Assert
            Assert.False(expert.IsActive);
        }
    }
}
