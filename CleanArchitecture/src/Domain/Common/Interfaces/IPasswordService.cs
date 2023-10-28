namespace CleanArchitecture.Domain.Common.Interfaces
{
    /// <summary>
    /// Hash and check password
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password">Plain password</param>
        /// <returns>Hashed password</returns>
        string HashPassword(string password);

        /// <summary>
        /// Check if password is valid
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        bool VerifyPassword(string hashedPassword, string password);
    }
}
