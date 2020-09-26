using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace TichuSensei.Core.Application.Players.Queries
{
    /// <summary>
    /// Returns a portion of the total players including their statistics using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetPlayersWithStatsWithPaginationQuery : IRequest<PaginatedList<PlayerWithStatsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

    }

    public class GetPlayersWithStatsWithPaginationQueryHandler : IRequestHandler<GetPlayersWithStatsWithPaginationQuery, PaginatedList<PlayerWithStatsDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayersWithStatsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PlayerWithStatsDTO>> Handle(GetPlayersWithStatsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            IOrderedQueryable<Domain.Entities.Player> SortedPlayers = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending) ? _context.Players.AsNoTracking()
               .OrderBy(x => x.Name) : _context.Players.AsNoTracking()
               .OrderByDescending(x => x.Name);

            return await SortedPlayers
                .ProjectTo<PlayerWithStatsDTO>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
