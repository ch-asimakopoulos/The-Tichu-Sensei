using FluentValidation;

namespace TichuSensei.Core.Application.Calls.Queries.Validators
{
    public class GetCallQueryValidator : AbstractValidator<GetCallQuery>
    {
        public GetCallQueryValidator()
        {
            RuleFor(ch => ch.id).GreaterThan(0).
                WithMessage("Call's Id should be a positive number.");
        }
    }
}


