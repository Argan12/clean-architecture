using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int Author { get; set; }  
    }
}
