using FluentValidation;
using TichuSensei.Core.Application.Rounds.Commands.Update;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Rounds.Commands.Validators
{
    public class UpdateRoundCommandValidator : AbstractValidator<UpdateRoundCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateRoundCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Round Id is required.");

        }


    }
}
