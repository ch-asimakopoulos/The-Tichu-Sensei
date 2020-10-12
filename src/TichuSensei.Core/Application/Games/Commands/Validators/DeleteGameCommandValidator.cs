using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Games.Commands.Delete;
using TichuSensei.Core.Domain.Entities;
using System.Collections.Generic;

namespace TichuSensei.Core.Application.Games.Commands.Validators
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteGameCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Game Id is required.")
                .MustAsync(GameWasCreatedByThisUser).WithMessage("The Game specified cannot be deleted by the current user.")
                .MustAsync(GameHasNoRounds).WithMessage("This Game has completed rounds. Deleting is not available. Try to delete the rounds before deleting the game or contact us at tichu.sensei@gmail.com for help.");

        }

        public async Task<bool> GameWasCreatedByThisUser(long GameId, CancellationToken cancellationToken)
        {
            var userId = await _context.Games.Where(pl => pl.GameId == GameId).
                Select(ch => new { p1id = ch.PlayerOne.UserId, p2id = ch.PlayerTwo.UserId }).
                FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return userId.p1id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase) || userId.p2id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }
        public async Task<bool> GameHasNoRounds(long GameId, CancellationToken cancellationToken)
        {
            ICollection<Round> rstats = await _context.GameStats.Where(pl => pl.GameId == GameId).Select(ch => ch.Rounds).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return rstats != null && rstats.Any();
        }

    }
}
