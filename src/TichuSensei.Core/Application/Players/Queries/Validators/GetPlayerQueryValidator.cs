using FluentValidation;

namespace TichuSensei.Core.Application.Players.Queries.Validators
{
    public class GetPlayerQueryValidator : AbstractValidator<GetPlayerQuery>
    {
        public GetPlayerQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Player's Id should be a positive number.");
        }
    }
}


