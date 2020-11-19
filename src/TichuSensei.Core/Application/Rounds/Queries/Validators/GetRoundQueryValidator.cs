using FluentValidation;

namespace TichuSensei.Core.Application.Rounds.Queries.Validators
{
    public class GetRoundQueryValidator : AbstractValidator<GetRoundQuery>
    {
        public GetRoundQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Round's Id should be a positive number.");
        }
    }
}


