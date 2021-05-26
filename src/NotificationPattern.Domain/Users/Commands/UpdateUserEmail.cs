using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserEmail : Notifiable
    {
        public string Email { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserEmailValidator());

            return !HasNotifications;
        }
    }
}
