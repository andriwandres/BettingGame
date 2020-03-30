using BettingGame.Core.Models.Transfer.Auth;
using FluentValidation;

namespace BettingGame.Api.Validation.Auth
{
    public class EmailExistsQueryValidator : AbstractValidator<EmailExistsQuery>
    {
        public EmailExistsQueryValidator()
        {
            RuleFor(query => query.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
