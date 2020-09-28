using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Players.Queries
{
    /// <summary>
    /// Returns a player specified by his unique Id.
    /// </summary>
    public class GetPlayerQuery : IRequest<PlayerDTO>
    {
        public long id;

    }

    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, PlayerDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayerQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlayerDTO> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Players.AsNoTracking().Where(ch => ch.PlayerId == request.id)
                .ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}

