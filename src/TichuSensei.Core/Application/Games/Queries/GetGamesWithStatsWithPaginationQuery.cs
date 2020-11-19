using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Games.Queries
{
    /// <summary>
    /// Returns a portion of the total Games including their statistics using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetGamesWithStatsWithPaginationQuery : IRequest<PaginatedList<GameWithStatsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

    }

    public class GetGamesWithStatsWithPaginationQueryHandler : IRequestHandler<GetGamesWithStatsWithPaginationQuery, PaginatedList<GameWithStatsDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGamesWithStatsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GameWithStatsDTO>> Handle(GetGamesWithStatsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            IQueryable<GameWithStatsDTO> GamesWithStatsNoTracking = _context.Games.AsNoTracking().ProjectTo<GameWithStatsDTO>(_mapper.ConfigurationProvider);
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);
            IOrderedQueryable<GameWithStatsDTO> sortedGames = sortAsc ? GamesWithStatsNoTracking.OrderBy(x => x.GameId) : GamesWithStatsNoTracking.OrderByDescending(x => x.GameId);
            return await sortedGames.PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
