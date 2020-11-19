using FluentValidation;

namespace TichuSensei.Core.Application.Games.Queries.Validators
{
    public class GetGameWithStatsQueryValidator : AbstractValidator<GetGameWithStatsQuery>
    {
        public GetGameWithStatsQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Game's Id should be a positive number.");
        }
    }
}