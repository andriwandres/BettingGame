using BettingGame.Core.Models.Transfer.Auth;
using FluentValidation;

namespace BettingGame.Api.Validation.Auth
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(credentials => credentials.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(credentials => credentials.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"^\S+$");
        }
    }
}
