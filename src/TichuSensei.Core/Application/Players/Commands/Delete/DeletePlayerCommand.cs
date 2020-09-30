using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Commands.Delete
{
    /// <summary>
    /// Deletes a Tichu Sensei player from the database.
    /// </summary>
    public class DeletePlayerCommand : IRequest<bool>
    {
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public long Id;
    }

    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeletePlayerCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            Player pl = _context.Players.Where(pl => pl.PlayerId == request.Id).FirstOrDefault();
            _context.Players.Remove(pl);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}