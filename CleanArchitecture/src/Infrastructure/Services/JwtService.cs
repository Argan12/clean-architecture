using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Services
{
    /// <summary>
    /// Generate and validate Jwt
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate JWT
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Jwt</returns>
        /// <exception cref="Exception"></exception>
        public string GenerateJwt(User user)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("pseudo", user.Pseudo!.Trim()),
                        new Claim("mail", user.Email!.Trim()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken securityToken = handler.CreateToken(tokenDescriptor);

                return handler.WriteToken(securityToken);

            }
            catch (Exception e)
            {
                throw new Exception("An error occurred during JWT generation.", e);
            }
        }
    }
}
