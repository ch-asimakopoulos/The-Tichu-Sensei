using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Calls.Commands.Delete
{
    /// <summary>
    /// Deletes a Tichu Sensei call from the database.
    /// </summary>
    public class DeleteCallCommand : IRequest<bool>
    {
        /// <summary>
        /// The call's unique Id.
        /// </summary>
        public long Id;
    }

    public class DeleteCallCommandHandler : IRequestHandler<DeleteCallCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCallCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteCallCommand request, CancellationToken cancellationToken)
        {
            Call cl = _context.Calls.Where(cl => cl.CallId == request.Id).FirstOrDefault();
            _context.Calls.Remove(cl);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}