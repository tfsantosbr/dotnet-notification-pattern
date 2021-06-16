using NotificationPattern.Domain.Commands;
using Xunit;

namespace NotificationPattern.Tests.Commands
{
    public class UpdateUserEmailTests
    {
        [Fact]
        public void ShouldMarkAsInvalidWhenUpdateUserEmailWithInvalidData()
        {
            // arrange

            var command = new UpdateUserEmail
            {
                Email = "",
            };

            // act & assert

            Assert.False(command.IsValid());
        }

        [Fact]
        public void ShouldMarkAsValidWhenUpdateUserEmailWithValidData()
        {
            // arrange

            var command = new UpdateUserEmail
            {
                Email = "tiago@email.com",
            };

            // act & assert

            Assert.True(command.IsValid());
        }
    }
}
