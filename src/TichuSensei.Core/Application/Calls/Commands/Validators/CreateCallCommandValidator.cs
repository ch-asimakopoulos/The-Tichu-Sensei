using FluentValidation;
using Microsoft.Extensions.Primitives;
using System.Linq;
using TichuSensei.Core.Application.Calls.Commands.Create;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Calls.Commands.Validators
{
    public class CreateCallCommandValidator : AbstractValidator<CreateCallCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private Round _round;

        public CreateCallCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.RoundId)
                .NotEmpty().WithMessage("Providing a round is required.")
                .Must(RoundExists).WithMessage("The round specified does not exist.");

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("Being a user is required.")
                .Must(UserExists).WithMessage("The user specified does not exist.");

            RuleFor(v => v.PlayerId)
                .NotEmpty().WithMessage("Providing a player is required.")
                .Must(PlayerExists).WithMessage("The player specified does not exist.");

            RuleFor(v => v.TeamId)
                .NotEmpty().WithMessage("Providing a team is required.")
                .Must(TeamExists).WithMessage("The team specified does not exist.");
        }

        public bool PlayerExists(long playerId) => playerId == _round.PlayerOneId || playerId == _round.PlayerTwoId || playerId == _round.PlayerThreeId || playerId == _round.PlayerFourId;

        public bool TeamExists(long teamId) => teamId == _round.TeamTwoId || teamId == _round.TeamOneId;

        public bool UserExists(string userId) => _currentUserService.UserId == userId;

        public bool RoundExists(long roundId) {
            _round = _context.Rounds.Where(rd => roundId == rd.RoundId).FirstOrDefault();
            return _round != null;
        }
    }
}
