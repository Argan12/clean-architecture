namespace CleanArchitecture.Domain.Common.Interfaces
{
    /// <summary>
    /// Users authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// User authentication
        /// If success, a JWT is return
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>JWT</returns>
        /// <exception cref="InvalidCredentialsException"></exception>
        string Login(string email, string password);
    }
}
