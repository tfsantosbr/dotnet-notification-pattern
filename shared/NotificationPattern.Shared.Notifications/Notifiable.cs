using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificationPattern.Shared.Notifications
{
    public abstract class Notifiable
    {
        // Fields

        private readonly List<Notification> _notifications = new();

        // Properties

        protected bool HasNotifications => _notifications.Any();

        // Abstract Methods

        public abstract bool IsValid();

        // Public Methods

        public IEnumerable<Notification> GetNotifications() => _notifications;

        public void AddNotification(string property, string description)
        {
            _notifications.Add(new Notification(property, description));
        }

        public void EnsureValidation()
        {
            if (IsValid()) return;

            var notifications = new StringBuilder();

            foreach (var notification in _notifications)
                notifications.AppendLine(notification.ToString());

            throw new InvalidOperationException(notifications.ToString());
        }

        // Protected Methods

        protected void UpdateValidation(IEnumerable<Notification> notifications)
        {
            if (!HasNotifications) return;

            foreach (var notification in notifications)
                _notifications.Add(notification);
        }

        protected void Validate(Notifiable validable) => UpdateValidation(validable.GetNotifications());

        protected void Validate(IValidator validator)
        {
            var context = new ValidationContext<object>(this);
            var result = validator.Validate(context);

            foreach (var item in result.Errors)
            {
                AddNotification(item.PropertyName, item.ErrorMessage);
            }
        }
    }
}
