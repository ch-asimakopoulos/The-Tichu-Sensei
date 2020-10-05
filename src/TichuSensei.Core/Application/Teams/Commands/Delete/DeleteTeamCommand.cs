using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Commands.Delete
{
    /// <summary>
    /// Deletes a Tichu Sensei Team from the database.
    /// </summary>
    public class DeleteTeamCommand : IRequest<bool>
    {
        /// <summary>
        /// The Team's unique Id.
        /// </summary>
        public long Id;
    }

    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeamCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            Team tm = _context.Teams.Where(tm => tm.TeamId == request.Id).FirstOrDefault();
            _context.Teams.Remove(tm);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}