using NotificationPattern.Domain.Users.Validators;
using NotificationPattern.Shared.Notifications;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserPassword : Notifiable
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public override bool IsValid()
        {
            Validate(new UpdateUserPasswordValidator());

            return !HasNotifications;
        }
    }
}
