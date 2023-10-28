using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser
{
    public sealed record CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
