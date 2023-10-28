using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Common.Interfaces
{
    /// <summary>
    /// Generate and validate Jwt
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generate JWT
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Jwt</returns>
        /// <exception cref="Exception"></exception>
        string GenerateJwt(User user);
    }
}
