namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserResponse
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
    }
}
