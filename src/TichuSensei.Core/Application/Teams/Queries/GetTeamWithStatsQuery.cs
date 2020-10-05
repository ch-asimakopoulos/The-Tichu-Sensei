using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Teams.Queries
{
    /// <summary>
    /// Returns a Team specified by his unique Id.
    /// </summary>
    public class GetTeamWithStatsQuery : IRequest<TeamWithStatsDTO>
    {
        public long id;

    }

    public class GetTeamWithStatsQueryHandler : IRequestHandler<GetTeamWithStatsQuery, TeamWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamWithStatsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamWithStatsDTO> Handle(GetTeamWithStatsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teams.AsNoTracking().Where(ch => ch.TeamId == request.id)
                .ProjectTo<TeamWithStatsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

