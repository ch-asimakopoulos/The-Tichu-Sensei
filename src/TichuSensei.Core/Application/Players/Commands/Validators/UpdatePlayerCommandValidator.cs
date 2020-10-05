using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Commands.Update;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Players.Commands.Validators
{
    public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdatePlayerCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.")
                .MustAsync(PlayerWasCreatedByThisUser).WithMessage("The player specified cannot be updated by the current user.");

        }

        public async Task<bool> PlayerWasCreatedByThisUser(long playerId, CancellationToken cancellationToken)
        {
            string userId = await _context.Players.Where(pl => pl.PlayerId == playerId).Select(ch => ch.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return userId.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }

    }
}
