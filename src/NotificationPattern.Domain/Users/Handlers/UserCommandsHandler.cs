using NotificationPattern.Domain.Commands;
using NotificationPattern.Domain.Core.ValueObjects;
using NotificationPattern.Domain.Entities;
using NotificationPattern.Domain.Users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Domain.Users.Handlers
{
    public class UserCommandsHandler
    {
        private readonly UserRepository _userRepository;

        public UserCommandsHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Handler(CreateUser request)
        {
            request.EnsureValidation();

            var user = new User(
                completeName: new CompleteName(request.FirstName, request.LastName),
                email: new Email(request.Email),
                password: new Password(request.Password)
                );

            _userRepository.Add(user);

            return user;
        }

        public void Handler(UpdateUserDetails request)
        {
            request.EnsureValidation();

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateDetails(new CompleteName(request.FirstName, request.LastName));

            _userRepository.Update(user);
        }

        public void Handler(UpdateUserEmail request)
        {
            request.EnsureValidation();

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdateEmail(new Email(request.Email));

            _userRepository.Update(user);
        }

        public void Handler(UpdateUserPassword request)
        {
            request.EnsureValidation();

            var user = _userRepository.GetById(request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            user.UpdatePassword(new Password(request.Password));

            _userRepository.Update(user);
        }
    }
}
