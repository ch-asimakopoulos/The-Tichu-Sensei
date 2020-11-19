using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Games.Queries
{
    /// <summary>
    /// Returns a Game specified by its unique Id.
    /// </summary>
    public class GetGameQuery : IRequest<GameDTO>
    {
        public long id;

    }

    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGameQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameDTO> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            return await _context.Games.AsNoTracking().Where(ch => ch.GameId == request.id)
                .ProjectTo<GameDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

