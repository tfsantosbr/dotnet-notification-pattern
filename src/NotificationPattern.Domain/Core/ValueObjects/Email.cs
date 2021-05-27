using NotificationPattern.Domain.Core.ValueObjects.Validators;
using NotificationPattern.Shared.Notifications;

namespace NotificationPattern.Domain.Core.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            EnsureValidation();
        }

        public string Address { get; private set; }

        public override bool IsValid()
        {
            Validate(new EmailValidator());

            return !HasNotifications;
        }

        public override string ToString()
        {
            return $"{Address}";
        }
    }
}
