using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Pseudo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
