using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Games.Commands.Create;

namespace TichuSensei.Core.Application.Games.Commands.Validators
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public CreateGameCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.PlayerOneId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id for the first player is required.");

            RuleFor(v => v.PlayerTwoId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id for the second player isrequired.");

            RuleFor(v => v.PlayerThreeId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id for the third player is required.");

            RuleFor(v => v.PlayerFourId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id for the fourth player is required.");

            RuleFor(v => v.TeamOneId)
                .NotEmpty().GreaterThan(0).WithMessage("A team Id for the first player is required.");

            RuleFor(v => v.TeamTwoId)
                .NotEmpty().GreaterThan(0).WithMessage("A team Id for the second player is required.");

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("Being a user is required.")
                .Must(UserExists).WithMessage("The user specified does not exist.");

        }
        public bool UserExists(string userId) => _currentUserService.UserId == userId;

    }
}
