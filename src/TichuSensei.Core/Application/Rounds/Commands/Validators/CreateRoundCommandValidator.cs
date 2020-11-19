using FluentValidation;
using TichuSensei.Core.Application.Rounds.Commands.Create;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Rounds.Commands.Validators
{
    public class CreateRoundCommandValidator : AbstractValidator<CreateRoundCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateRoundCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.PlayerOneId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.PlayerTwoId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.PlayerThreeId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.PlayerFourId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.TeamOneId)
                .NotEmpty().GreaterThan(0).WithMessage("A team Id is required.");

            RuleFor(v => v.TeamTwoId)
                .NotEmpty().GreaterThan(0).WithMessage("A team Id is required.");

        }

    }
}
