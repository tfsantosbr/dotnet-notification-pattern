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
            Assert.Contains("FirstName", exception.Message);
            Assert.Contains("LastName", exception.Message);
            Assert.Contains("Email", exception.Message);
            Assert.Contains("Password", exception.Message);
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

            var isValidUser = user.IsValid();

            // assert

            Assert.True(isValidUser);
        }
    }
}
