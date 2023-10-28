using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    /// <summary>
    /// User authentication
    /// </summary>
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Log user in
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Jwt</returns>
        [HttpPost]
        public IActionResult Login(User user)
        {
            string jwt = _authenticationService.Login(user.Email!, user.Password!);

            return Ok(jwt);
        }
    }
}
