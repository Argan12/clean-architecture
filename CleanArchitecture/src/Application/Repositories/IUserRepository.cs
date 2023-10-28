using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>User</returns>
        User GetByEmail(string email);

        /// <summary>
        /// Get user by pseudo
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns>User</returns>
        User GetByPseudo(string pseudo);
    }
}
