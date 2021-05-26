using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationPattern.Domain.Commands;
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

            var user = new User(request.FirstName, request.LastName, request.Email, request.Password);
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

            user.UpdateDetails(request.FirstName, request.LastName);

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

            user.UpdateEmail(request.Email);

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

            user.UpdatePassword(request.Password);

            return NoContent();
        }
    }
}
