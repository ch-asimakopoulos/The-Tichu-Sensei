using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Rounds.Commands.Delete
{
    /// <summary>
    /// Deletes a Tichu Sensei Round from the database.
    /// </summary>
    public class DeleteRoundCommand : IRequest<bool>
    {
        /// <summary>
        /// The Round's unique Id.
        /// </summary>
        public long Id;
    }

    public class DeleteRoundCommandHandler : IRequestHandler<DeleteRoundCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoundCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteRoundCommand request, CancellationToken cancellationToken)
        {
            Round pl = _context.Rounds.Where(pl => pl.RoundId == request.Id).FirstOrDefault();
            _context.Rounds.Remove(pl);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}