using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserEmail : Notifiable
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserEmailValidator());

            return !HasNotifications;
        }
    }
}
