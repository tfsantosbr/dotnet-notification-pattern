using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationPattern.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return Ok();
        }

        [HttpPut("profile")]
        public IActionResult UpdateUserProfile()
        {
            return Ok();
        }

        [HttpPut("email")]
        public IActionResult UpdateUserEmail()
        {
            return Ok();
        }

        [HttpPut("password")]
        public IActionResult UpdateUserPassword()
        {
            return Ok();
        }
    }
}
