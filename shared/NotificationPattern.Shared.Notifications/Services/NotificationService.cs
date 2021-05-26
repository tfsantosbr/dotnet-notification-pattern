using NotificationPattern.Shared.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Shared.Notifications.Services
{
    public class NotificationService : INotificationService, IDisposable
    {
        private readonly List<Notification> _notifications = new();

        public IList<Notification> GetNotifications() => _notifications;

        public bool HasNotifications() => _notifications.Any();

        public void AddNotifications(IEnumerable<Notification> notifications) => _notifications.AddRange(notifications);

        public void AddNotification(Notification notification) => _notifications.Add(notification);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notifications.Clear();
            }
        }
    }
}
