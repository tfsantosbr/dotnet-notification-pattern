using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserDetails : Notifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserDetailsValidator());

            return !HasNotifications;
        }
    }
}
