using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Teams.Commands.Update;

namespace TichuSensei.Core.Application.Teams.Commands.Validators
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateTeamCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Team Id is required.")
                .MustAsync(TeamWasCreatedByThisUser).WithMessage("The Team specified cannot be updated by the current user.");

        }

        public async Task<bool> TeamWasCreatedByThisUser(long TeamId, CancellationToken cancellationToken)
        {
            var userId = await _context.Teams.Where(pl => pl.TeamId == TeamId).
                Select(ch => new { p1id = ch.PlayerOne.UserId, p2id = ch.PlayerTwo.UserId }).
                FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return userId.p1id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase) || userId.p2id.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }

    }
}
