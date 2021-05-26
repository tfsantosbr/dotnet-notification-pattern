using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;
using System;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserDetails : Notifiable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserDetailsValidator());

            return !HasNotifications;
        }
    }
}
