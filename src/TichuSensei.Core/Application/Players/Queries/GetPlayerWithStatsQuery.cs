using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Players.Queries
{
    /// <summary>
    /// Returns a player specified by his unique Id.
    /// </summary>
    public class GetPlayerWithStatsQuery : IRequest<PlayerWithStatsDTO>
    {
        public long id;

    }

    public class GetPlayerWithStatsQueryHandler : IRequestHandler<GetPlayerWithStatsQuery, PlayerWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayerWithStatsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlayerWithStatsDTO> Handle(GetPlayerWithStatsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Players.AsNoTracking().Where(ch => ch.PlayerId == request.id)
                .ProjectTo<PlayerWithStatsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}

