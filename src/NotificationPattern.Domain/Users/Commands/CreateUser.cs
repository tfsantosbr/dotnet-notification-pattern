using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Commands
{
    public class CreateUser : Notifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }

        public override bool IsValid()
        {
            Validate(new CreateUserValidator());

            return !HasNotifications;
        }
    }
}
