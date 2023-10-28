using CleanArchitecture.Domain.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Hash and check password
    /// </summary>
    public class PasswordService : IPasswordService
    {
        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password">Plain password</param>
        /// <returns>Hashed password</returns>
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Check if password is valid
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        public bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
