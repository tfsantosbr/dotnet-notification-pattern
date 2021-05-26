using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserPassword : Notifiable
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserPasswordValidator());

            return !HasNotifications;
        }
    }
}
