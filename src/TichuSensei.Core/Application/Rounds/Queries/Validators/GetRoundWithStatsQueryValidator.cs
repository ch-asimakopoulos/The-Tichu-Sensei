using FluentValidation;

namespace TichuSensei.Core.Application.Rounds.Queries.Validators
{
    public class GetRoundWithTeamAndPlayerInfoQueryValidator : AbstractValidator<GetRoundWithTeamAndPlayerInfoQuery>
    {
        public GetRoundWithTeamAndPlayerInfoQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Round's Id should be a positive number.");
        }
    }
}