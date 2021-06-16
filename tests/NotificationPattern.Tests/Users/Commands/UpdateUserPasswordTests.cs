using NotificationPattern.Domain.Commands;
using Xunit;

namespace NotificationPattern.Tests.Commands
{
    public class UpdateUserPasswordTests
    {
        [Fact]
        public void ShouldMarkAsInvalidWhenUpdateUserPasswordWithInvalidData()
        {
            // arrange

            var command = new UpdateUserPassword
            {
                Password = "",
                ConfirmPassword = ""
            };

            // act & assert

            Assert.False(command.IsValid());
        }

        [Fact]
        public void ShouldMarkAsValidWhenUpdateUserPasswordWithValidData()
        {
            // arrange

            var command = new UpdateUserPassword
            {
                Password = "Passw0rd",
                ConfirmPassword = "Passw0rd"
            };

            // act & assert

            Assert.True(command.IsValid());
        }
    }
}
