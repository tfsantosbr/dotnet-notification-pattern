using NotificationPattern.Domain.Commands;
using NotificationPattern.Domain.Core.ValueObjects;
using NotificationPattern.Domain.Entities;
using NotificationPattern.Domain.Users.Repository;
using NotificationPattern.Shared.Notifications;
using NotificationPattern.Shared.Notifications.Interfaces;
using System;

namespace NotificationPattern.Domain.Users.Handlers
{
    public class UserCommandsHandler
    {
        private readonly UserRepository _userRepository;
        private readonly INotifier _notifier;

        public UserCommandsHandler(UserRepository userRepository, INotifier notifier)
        {
            _userRepository = userRepository;
            _notifier = notifier;
        }

        public User Handle(CreateUser request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return null;
            }

            var user = new User(
                completeName: new CompleteName(request.FirstName, request.LastName),
                email: new Email(request.Email),
                password: new Password(request.Password),
                birthDate: request.BirthDate
                );

            _userRepository.Add(user);

            if (_userRepository.AnyEmail(user.Email, user.Id))
            {
                _notifier.AddNotification(new Notification("Email", $"E-mail '{user.Email}' alread exists."));
                return null;
            }

            return user;
        }

        public void Handle(UpdateUserDetails request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateDetails(new CompleteName(request.FirstName, request.LastName));

            _userRepository.Update(user);
        }

        public void Handle(UpdateUserEmail request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateEmail(new Email(request.Email));

            _userRepository.Update(user);
        }

        public void Handle(UpdateUserPassword request)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdatePassword(new Password(request.Password));

            _userRepository.Update(user);
        }
    }
}
