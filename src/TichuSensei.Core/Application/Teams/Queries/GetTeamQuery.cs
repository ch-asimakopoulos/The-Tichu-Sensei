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
    public class GetTeamQuery : IRequest<TeamDTO>
    {
        public long id;

    }

    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, TeamDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamDTO> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teams.AsNoTracking().Where(ch => ch.TeamId == request.id)
                .ProjectTo<TeamDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

