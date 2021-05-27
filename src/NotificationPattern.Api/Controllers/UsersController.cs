using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationPattern.Domain.Commands;
using NotificationPattern.Domain.Core.ValueObjects;
using NotificationPattern.Domain.Entities;
using NotificationPattern.Domain.Users.Handlers;
using System.Collections.Generic;
using System.Linq;

namespace NotificationPattern.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserCommandsHandler _createUserHandler;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        public UsersController(UserCommandsHandler createUserHandler)
        {
            _createUserHandler = createUserHandler;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUser request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            var user = _createUserHandler.Handler(request);

            return Created($"users/{user.Id}", user);
        }

        [HttpPut("details")]
        public IActionResult UpdateUserDetails(UpdateUserDetails request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            _createUserHandler.Handler(request);

            return NoContent();
        }

        [HttpPut("email")]
        public IActionResult UpdateUserEmail(UpdateUserEmail request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            _createUserHandler.Handler(request);

            return NoContent();
        }

        [HttpPut("password")]
        public IActionResult UpdateUserPassword(UpdateUserPassword request)
        {
            if (!request.IsValid())
                return BadRequest(request.GetNotifications());

            _createUserHandler.Handler(request);

            return NoContent();
        }
    }
}
