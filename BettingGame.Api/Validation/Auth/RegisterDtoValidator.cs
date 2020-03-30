using BettingGame.Core.Models.Transfer.Auth;
using FluentValidation;

namespace BettingGame.Api.Validation.Auth
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(credentials => credentials.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(credentials => credentials.Username)
                .NotEmpty()
                .MinimumLength(3)
                .Matches(@"^\S+$");

            RuleFor(credentials => credentials.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"^\S+$");
        }
    }
}
