using FluentValidation;
using TichuSensei.Core.Application.Teams.Commands.Update;

namespace TichuSensei.Core.Application.Teams.Commands.Validators
{
    public class UpdateTeamStatsCommandValidator : AbstractValidator<UpdateTeamStatsCommand>
    {
        public UpdateTeamStatsCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Team Id is required.");
        }

    }
}
