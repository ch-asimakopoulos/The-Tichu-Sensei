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
    /// Returns a portion of the total players including their statistics using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetPlayersWithStatsWithPaginationQuery : IRequest<PaginatedList<PlayerWithStatsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

        public Domain.Enums.Player.OrderByStats OrderByStats = Domain.Enums.Player.OrderByStats.Name;

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
            IQueryable<PlayerWithStatsDTO> playersWithStatsNoTracking = _context.Players.AsNoTracking().ProjectTo<PlayerWithStatsDTO>(_mapper.ConfigurationProvider);
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);
            IOrderedQueryable<PlayerWithStatsDTO> sortedPlayers = request.OrderByStats switch
            {
                Domain.Enums.Player.OrderByStats.Name => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.Name) :
                                       playersWithStatsNoTracking.OrderByDescending(x => x.Name),
                Domain.Enums.Player.OrderByStats.DateCreated => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.DateCreated) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.DateCreated),
                Domain.Enums.Player.OrderByStats.GamesWonPercentage => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.GamesWonPercentage) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.GamesWonPercentage),
                Domain.Enums.Player.OrderByStats.RoundsWonPercentage => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.RoundsWonPercentage) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.RoundsWonPercentage),
                Domain.Enums.Player.OrderByStats.PointsPerRound => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.PointsPerRound) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.PointsPerRound),
                Domain.Enums.Player.OrderByStats.GrandTichuCallsWonPercentage => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.GrandTichuCallsWonPercentage) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.GrandTichuCallsWonPercentage),
                Domain.Enums.Player.OrderByStats.TichuCallsWonPercentage => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.TichuCallsWonPercentage) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.TichuCallsWonPercentage),
                Domain.Enums.Player.OrderByStats.HighCardsPerRound => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.HighCardsPerRound) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.HighCardsPerRound),
                Domain.Enums.Player.OrderByStats.OpponentsHighCardsPerRound => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.OpponentsHighCardsPerRound) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.OpponentsHighCardsPerRound),
                Domain.Enums.Player.OrderByStats.BombsPerRound => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.BombsPerRound) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.BombsPerRound),
                Domain.Enums.Player.OrderByStats.OpponentsBombsPerRound => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.OpponentsBombsPerRound) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.OpponentsBombsPerRound),
                _ => sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.Name) :
                    playersWithStatsNoTracking.OrderByDescending(x => x.Name),
            };
            return await sortedPlayers.PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
