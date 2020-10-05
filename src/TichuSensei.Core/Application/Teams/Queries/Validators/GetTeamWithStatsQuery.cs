using FluentValidation;

namespace TichuSensei.Core.Application.Teams.Queries.Validators
{
    public class GetTeamQueryValidator : AbstractValidator<GetTeamQuery>
    {
        public GetTeamQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Team's Id should be a positive number.");
        }
    }
}