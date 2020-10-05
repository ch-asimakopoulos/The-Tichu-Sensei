using FluentValidation;

namespace TichuSensei.Core.Application.Teams.Queries.Validators
{
    public class GetTeamWithStatsQueryValidator : AbstractValidator<GetTeamWithStatsQuery>
    {
        public GetTeamWithStatsQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Team's Id should be a positive number.");
        }
    }
}