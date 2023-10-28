using FluentValidation;

namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Pseudo)
                .MinimumLength(5)
                .MaximumLength(20);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid mail address");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")
                .WithMessage("Weak password");
        }
    }
}
