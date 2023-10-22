using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string? Pseudo { get; set; }
        public string? Content { get; set; }
        public int Article { get; set; }
    }
}
