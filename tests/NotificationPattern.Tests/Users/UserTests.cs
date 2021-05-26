using NotificationPattern.Domain.Entities;
using System;
using Xunit;

namespace NotificationPattern.Tests.Users
{
    public class UserTests
    {
        [Fact]
        public void ShouldThrowAnExceptionWhenInstanceUserWithInvalidData()
        {
            // arrange

            static void createUser() => new User(
                firstName: "",
                lastName: "",
                email: "",
                password: ""
                );

            // act

            var exception = Record.Exception(createUser);

            // assert

            Assert.IsType<InvalidOperationException>(exception);
        }

        [Fact]
        public void ShouldBeValidUserWhencreatedWithValidData()
        {
            // arrange

            var user = new User(
                firstName: "Tiago",
                lastName: "Santos",
                email: "tiago@email.com",
                password: "PaSsW0rd"
                );

            // act

            var isValid = user.IsValid();

            // assert

            Assert.True(isValid);
        }
    }
}
