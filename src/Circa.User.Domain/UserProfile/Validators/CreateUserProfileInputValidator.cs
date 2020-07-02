using Circa.User.Domain.UserProfile.Inputs;
using FluentValidation;

namespace Circa.Users.Domain.UserProfile
{
    public class CreateUserProfileInputValidator : AbstractValidator<CreateUserProfileInput>
    {
        public CreateUserProfileInputValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithMessage("User first name is required");
            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("User last name is required");
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("User email is required");
            RuleFor(a => a.KeycloakId)
                .NotEmpty()
                .WithMessage("User keycloak id is required");
            RuleFor(a => a.Nickname)
                .NotEmpty()
                .WithMessage("User nickname is required");
        }
    }
}
