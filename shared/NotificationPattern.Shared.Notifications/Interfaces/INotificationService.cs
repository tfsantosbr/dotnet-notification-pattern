using System.Collections.Generic;

namespace NotificationPattern.Shared.Notifications.Interfaces
{
    public interface INotificationService
    {
        bool HasNotifications();

        IList<Notification> GetNotifications();

        void AddNotification(Notification notification);
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}
