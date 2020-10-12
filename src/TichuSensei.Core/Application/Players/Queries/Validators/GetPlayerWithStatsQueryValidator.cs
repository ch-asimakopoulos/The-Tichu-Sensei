using FluentValidation;

namespace TichuSensei.Core.Application.Players.Queries.Validators
{
    public class GetPlayerWithStatsQueryValidator : AbstractValidator<GetPlayerWithStatsQuery>
    {
        public GetPlayerWithStatsQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Player's Id should be a positive number.");
        }
    }
}