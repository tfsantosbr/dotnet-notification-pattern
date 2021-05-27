using NotificationPattern.Domain.Core.ValueObjects.Validators;
using NotificationPattern.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Domain.Core.ValueObjects
{
    public class Password : Notifiable
    {
        public Password(string value)
        {
            Value = value;

            EnsureValidation();
        }

        public string Value { get; private set; }

        public override bool IsValid()
        {
            Validate(new PasswordValidator());

            return !HasNotifications;
        }
    }
}
