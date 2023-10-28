using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Common.Exceptions;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Users authentication
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtService _jwtService;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jwtService"></param>
        /// <param name="passwordService"></param>
        /// <param name="userRepository"></param>
        public AuthenticationService(IJwtService jwtService, IPasswordService passwordService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        /// <summary>
        /// User authentication
        /// If success, a JWT is return
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>JWT</returns>
        /// <exception cref="InvalidCredentialsException"></exception>
        public string Login(string email, string password)
        {
            User user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new InvalidCredentialsException("Invalid credentials");
            }

            if (!_passwordService.VerifyPassword(user.Password!, password))
            {
                throw new InvalidCredentialsException("Invalid credentials");
            }

            return _jwtService.GenerateJwt(user);
        }
    }
}
