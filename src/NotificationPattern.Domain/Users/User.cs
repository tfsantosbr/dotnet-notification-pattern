using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Entities
{
    public class User : Notifiable
    {
        public User(string firstName, string lastName, string email, string password, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;

            EnsureValidation();
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void UpdateDetails(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public override bool IsValid()
        {
            Validate(new UserValidator());

            return !HasNotifications;
        }
    }
}
