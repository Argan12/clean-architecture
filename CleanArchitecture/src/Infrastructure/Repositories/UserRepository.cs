using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repositories
{
    /// <summary>
    /// User queries
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(CleanArchitectureDbContext context) : base(context) 
        {
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>User</returns>
        public User GetByEmail(string email) => _context.Users.FirstOrDefault(x => x.Email == email)!;

        /// <summary>
        /// Get user by pseudo
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns>User</returns>
        public User GetByPseudo(string pseudo) => _context.Users.FirstOrDefault(y => y.Pseudo == pseudo)!;
    }
}
