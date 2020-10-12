using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Commands.Delete
{
    /// <summary>
    /// Deletes a Tichu Sensei Game from the database.
    /// </summary>
    public class DeleteGameCommand : IRequest<bool>
    {
        /// <summary>
        /// The Game's unique Id.
        /// </summary>
        public long Id;
    }

    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGameCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            Game gm = _context.Games.Where(gm => gm.GameId == request.Id).FirstOrDefault();
            _context.Games.Remove(gm);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}