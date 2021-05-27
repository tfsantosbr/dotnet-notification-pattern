using NotificationPattern.Domain.Core.ValueObjects;
using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Entities
{
    public class User : Notifiable
    {
        public User(CompleteName completeName, Email email, Password password, DateTime birthDate, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CompleteName = completeName;
            Email = email;
            Password = password;
            BirthDate = birthDate;

            EnsureValidation();
        }

        public Guid Id { get; private set; }
        public CompleteName CompleteName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        public void UpdateDetails(CompleteName completeName)
        {
            CompleteName = completeName;
        }

        public void UpdatePassword(Password password)
        {
            Password = password;
        }

        public void UpdateEmail(Email email)
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
