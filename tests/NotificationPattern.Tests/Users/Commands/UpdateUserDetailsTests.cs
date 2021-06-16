using NotificationPattern.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotificationPattern.Tests.Commands
{
    public class UpdateUserDetailsTests
    {
        [Fact]
        public void ShouldMarkAsInvalidWhenUpdateUserDetailsWithInvalidData()
        {
            // arrange

            var command = new UpdateUserDetails
            {
                FirstName = "",
                LastName = "",
            };

            // act & assert

            Assert.False(command.IsValid());
        }

        [Fact]
        public void ShouldMarkAsValidWhenUpdateUserDetailsWithValidData()
        {
            // arrange

            var command = new UpdateUserDetails
            {
                FirstName = "Tiago",
                LastName = "Santos",
            };

            // act & assert

            Assert.True(command.IsValid());
        }
    }
}
