using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Domain.Commands;
using NotificationPattern.Domain.Users.Handlers;
using NotificationPattern.Domain.Users.Repository;
using NotificationPattern.Shared.Notifications;
using NotificationPattern.Shared.Notifications.Interfaces;

namespace NotificationPattern.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly UserCommandsHandler _handler;
        private readonly UserRepository _userRepository;
        private readonly INotifier _notifier;

        public UsersController(UserCommandsHandler handler, INotifier notifier, UserRepository userRepository)
        {
            _handler = handler;
            _notifier = notifier;
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUser request)
        {
            var user = _handler.Handle(request);

            if (_notifier.HasNotifications())
            {
                return UnprocessableEntity(_notifier.GetNotifications());
            }

            return Created($"users/{user.Id}", user);
        }

        [HttpPut("details")]
        public IActionResult UpdateUserDetails(UpdateUserDetails request)
        {
            //if (!_userRepository.AnyUser(request.Id))
            //{
            //    return NotFound(new Notification("User", "User not found"));
            //}

            _handler.Handle(request);

            if (!_notifier.HasNotifications())
            {
                return BadRequest(_notifier.GetNotifications());
            }

            return NoContent();
        }

        [HttpPut("email")]
        public IActionResult UpdateUserEmail(UpdateUserEmail request)
        {
            if (!_userRepository.AnyUser(request.Id))
            {
                return NotFound();
            }

            _handler.Handle(request);

            if (!_notifier.HasNotifications())
            {
                return BadRequest(_notifier.GetNotifications());
            }

            return NoContent();
        }

        [HttpPut("password")]
        public IActionResult UpdateUserPassword(UpdateUserPassword request)
        {
            if (!_userRepository.AnyUser(request.Id))
            {
                return NotFound();
            }

            _handler.Handle(request);

            if (!_notifier.HasNotifications())
            {
                return BadRequest(_notifier.GetNotifications());
            }

            return NoContent();
        }
    }
}
