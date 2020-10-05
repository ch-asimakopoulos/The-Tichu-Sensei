using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Commands.Delete;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Commands.Validators
{
    public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeletePlayerCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.")
                .MustAsync(PlayerWasCreatedByThisUser).WithMessage("The player specified cannot be deleted by the current user.")
                .MustAsync(PlayerHasNoGames).WithMessage("This player has participated in a game. Deleting is not available. Contact us at tichu.sensei@gmail.com for help.");

        }

        public async Task<bool> PlayerWasCreatedByThisUser(long playerId, CancellationToken cancellationToken)
        {
            string userId = await _context.Players.Where(pl => pl.PlayerId == playerId).Select(ch => ch.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return userId.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }
        public async Task<bool> PlayerHasNoGames(long playerId, CancellationToken cancellationToken)
        {
            PlayerStats stats = await _context.Players.Where(pl => pl.PlayerId == playerId).Select(ch => ch.Stats).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return 0 == stats.RoundsTotal;
        }

    }
}
