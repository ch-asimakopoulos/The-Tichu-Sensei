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
    public class GetGameWithStatsQuery : IRequest<GameWithStatsDTO>
    {
        public long id;

    }

    public class GetGameWithStatsQueryHandler : IRequestHandler<GetGameWithStatsQuery, GameWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGameWithStatsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameWithStatsDTO> Handle(GetGameWithStatsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Games.AsNoTracking().Where(ch => ch.GameId == request.id)
                .ProjectTo<GameWithStatsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

