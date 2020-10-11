using FluentValidation;
using TichuSensei.Core.Application.Players.Commands.Update;

namespace TichuSensei.Core.Application.Players.Commands.Validators
{
    public class UpdatePlayerStatsCommandValidator : AbstractValidator<UpdatePlayerStatsCommand>
    {
        public UpdatePlayerStatsCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");
        }

    }
}
