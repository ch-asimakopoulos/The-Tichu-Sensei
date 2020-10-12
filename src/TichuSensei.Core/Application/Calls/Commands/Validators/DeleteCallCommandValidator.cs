using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Commands.Delete;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Calls.Commands.Validators
{
    public class DeleteCallCommandValidator : AbstractValidator<DeleteCallCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCallCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.Id)
                .NotEmpty().GreaterThan(0).WithMessage("A Call Id is required.")
                .MustAsync(CallWasCreatedByThisUser).WithMessage("Only the user who created this call can delete it");
        }

        public async Task<bool> CallWasCreatedByThisUser(long CallId, CancellationToken cancellationToken)
        {
            long playerId = await _context.Calls.Where(cl => cl.CallId == CallId).Select(ch => ch.PlayerId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            string userId = await _context.Players.Where(pl => pl.PlayerId == playerId).Select(ch => ch.UserId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return userId.Equals(_currentUserService.UserId, StringComparison.OrdinalIgnoreCase);
        }

    }
}
