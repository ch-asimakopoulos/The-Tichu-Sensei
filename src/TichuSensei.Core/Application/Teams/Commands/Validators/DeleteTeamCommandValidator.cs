using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Teams.Commands.Delete;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Commands.Validators
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTeamCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Team Id is required.")
                .MustAsync(TeamWasCreatedByThisUser).WithMessage("The Team specified cannot be deleted by the current user.")
                .MustAsync(TeamHasNoGames).WithMessage("This Team has participated in a game. Deleting is not available. Contact us at tichu.sensei@gmail.com for help.");

        }

        public async Task<bool> TeamWasCreatedByThisUser(long TeamId, CancellationToken cancellationToken)
        {
            var userId = await _context.Teams.Where(pl => pl.TeamId == TeamId).
                Select(ch => new { p1id = ch.PlayerOne.UserId, p2id = ch.PlayerTwo.UserId }).
                FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return userId.p1id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase) || userId.p2id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }
        public async Task<bool> TeamHasNoGames(long TeamId, CancellationToken cancellationToken)
        {
            TeamStats stats = await _context.Teams.Where(pl => pl.TeamId == TeamId).Select(ch => ch.Stats).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return 0 == stats.RoundsTotal;
        }

    }
}
