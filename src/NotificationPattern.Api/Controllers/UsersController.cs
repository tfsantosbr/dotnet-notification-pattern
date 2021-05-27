using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationPattern.Domain.Commands;
using NotificationPattern.Domain.Core.ValueObjects;
using NotificationPattern.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private static readonly List<User> _users = new();

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUser request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            var user = new User(
                completeName: new CompleteName(request.FirstName, request.LastName),
                email: new Email(request.Email),
                password: new Password(request.Password)
                );

            _users.Add(user);

            return Created($"users/{user.Id}", user);
        }

        [HttpPut("details")]
        public IActionResult UpdateUserDetails(UpdateUserDetails request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            var user = _users.FirstOrDefault(u => u.Id == request.Id);

            if (user is null)
                return NotFound();

            user.UpdateDetails(new CompleteName(request.FirstName, request.LastName));

            return NoContent();
        }

        [HttpPut("email")]
        public IActionResult UpdateUserEmail(UpdateUserEmail request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            var user = _users.FirstOrDefault(u => u.Id == request.Id);

            if (user is null)
                return NotFound();

            user.UpdateEmail(new Email(request.Email));

            return NoContent();
        }

        [HttpPut("password")]
        public IActionResult UpdateUserPassword(UpdateUserPassword request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            var user = _users.FirstOrDefault(u => u.Id == request.Id);

            if (user is null)
                return NotFound();

            user.UpdatePassword(new Password(request.Password));

            return NoContent();
        }
    }
}
