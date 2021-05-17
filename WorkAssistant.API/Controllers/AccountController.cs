using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WorkAssistant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUserInformation()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Register()
        {
            return NoContent();
        }

        [HttpPut]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok(Guid.NewGuid());
        }

        [HttpPut]
        [Route("logout")]
        public IActionResult LogOut()
        {
            return Ok();
        }
    }
}