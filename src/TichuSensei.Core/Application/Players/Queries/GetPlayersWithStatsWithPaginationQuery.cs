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
            IOrderedQueryable<PlayerWithStatsDTO> sortedPlayers;
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);

            switch (request.OrderByStats)
            {
                case Domain.Enums.Player.OrderByStats.Name:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.Name) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.Name);
                    break;
                case Domain.Enums.Player.OrderByStats.DateCreated:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.DateCreated) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.DateCreated);
                    break;
                case Domain.Enums.Player.OrderByStats.GamesWonPercentage:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.GamesWonPercentage) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.GamesWonPercentage);
                    break;
                case Domain.Enums.Player.OrderByStats.RoundsWonPercentage:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.RoundsWonPercentage) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.RoundsWonPercentage);
                    break;
                case Domain.Enums.Player.OrderByStats.PointsPerRound:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.PointsPerRound) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.PointsPerRound);
                    break;
                case Domain.Enums.Player.OrderByStats.GrandTichuCallsWonPercentage:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.GrandTichuCallsWonPercentage) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.GrandTichuCallsWonPercentage);
                    break;
                case Domain.Enums.Player.OrderByStats.TichuCallsWonPercentage:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.TichuCallsWonPercentage) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.TichuCallsWonPercentage);
                    break;
                case Domain.Enums.Player.OrderByStats.HighCardsPerRound:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.HighCardsPerRound) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.HighCardsPerRound);
                    break;
                case Domain.Enums.Player.OrderByStats.OpponentsHighCardsPerRound:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.OpponentsHighCardsPerRound) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.OpponentsHighCardsPerRound);
                    break;
                case Domain.Enums.Player.OrderByStats.BombsPerRound:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.BombsPerRound) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.BombsPerRound);
                    break;
                case Domain.Enums.Player.OrderByStats.OpponentsBombsPerRound:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.PlayerStats.OpponentsBombsPerRound) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.PlayerStats.OpponentsBombsPerRound);
                    break;
                default:
                    sortedPlayers = sortAsc ? playersWithStatsNoTracking.OrderBy(x => x.Name) :
                        playersWithStatsNoTracking.OrderByDescending(x => x.Name);
                    break;
            }


            return await sortedPlayers.PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
