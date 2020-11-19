using FluentValidation;

namespace TichuSensei.Core.Application.Games.Queries.Validators
{
    public class GetGameQueryValidator : AbstractValidator<GetGameQuery>
    {
        public GetGameQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Game's Id should be a positive number.");
        }
    }
}


