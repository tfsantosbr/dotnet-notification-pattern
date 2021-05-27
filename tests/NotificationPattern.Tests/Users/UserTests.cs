using NotificationPattern.Domain.Core.ValueObjects;
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
                completeName: null,
                email: null,
                password: null,
                birthDate: new DateTime()
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
                completeName: new CompleteName("Tiago","Santos"),
                email: new Email("tiago@email.com"),
                password: new Password("PaSsW0rd"),
                birthDate: new DateTime(1987,3,13)
                );

            // act

            var isValid = user.IsValid();

            // assert

            Assert.True(isValid);
        }
    }
}
