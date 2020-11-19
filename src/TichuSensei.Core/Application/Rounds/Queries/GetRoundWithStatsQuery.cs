using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Rounds.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Rounds.Queries
{
    /// <summary>
    /// Returns a Round specified by its unique Id.
    /// </summary>
    public class GetRoundWithTeamAndPlayerInfoQuery : IRequest<RoundWithTeamAndPlayerInfoDTO>
    {
        public long id;

    }

    public class GetRoundWithTeamAndPlayerInfoQueryHandler : IRequestHandler<GetRoundWithTeamAndPlayerInfoQuery, RoundWithTeamAndPlayerInfoDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoundWithTeamAndPlayerInfoQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoundWithTeamAndPlayerInfoDTO> Handle(GetRoundWithTeamAndPlayerInfoQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rounds.AsNoTracking().Where(ch => ch.RoundId == request.id)
                .ProjectTo<RoundWithTeamAndPlayerInfoDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

