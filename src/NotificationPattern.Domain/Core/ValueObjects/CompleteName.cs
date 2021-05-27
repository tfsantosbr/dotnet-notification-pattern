using NotificationPattern.Domain.Core.ValueObjects.Validators;
using NotificationPattern.Shared.Notifications;

namespace NotificationPattern.Domain.Core.ValueObjects
{
    public class CompleteName : Notifiable
    {
        public CompleteName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            DisplayName = ToString();

            EnsureValidation();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get; private set; }

        public override bool IsValid()
        {
            Validate(new CompleteNameValidator());

            return !HasNotifications;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
