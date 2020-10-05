using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Teams.Queries
{
    /// <summary>
    /// Returns a portion of the total Teams including their statistics using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetTeamsWithStatsWithPaginationQuery : IRequest<PaginatedList<TeamWithStatsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

        public Domain.Enums.Team.OrderByStats OrderByStats = Domain.Enums.Team.OrderByStats.Name;

    }

    public class GetTeamsWithStatsWithPaginationQueryHandler : IRequestHandler<GetTeamsWithStatsWithPaginationQuery, PaginatedList<TeamWithStatsDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamsWithStatsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TeamWithStatsDTO>> Handle(GetTeamsWithStatsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            IQueryable<TeamWithStatsDTO> TeamsWithStatsNoTracking = _context.Teams.AsNoTracking().ProjectTo<TeamWithStatsDTO>(_mapper.ConfigurationProvider);
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);
            
            IOrderedQueryable<TeamWithStatsDTO> sortedTeams = request.OrderByStats switch
            {
                Domain.Enums.Team.OrderByStats.Name => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.Name) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.Name),
                Domain.Enums.Team.OrderByStats.DateCreated => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.DateCreated) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.DateCreated),
                Domain.Enums.Team.OrderByStats.GamesWonPercentage => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.GamesWonPercentage) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.GamesWonPercentage),
                Domain.Enums.Team.OrderByStats.RoundsWonPercentage => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.RoundsWonPercentage) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.RoundsWonPercentage),
                Domain.Enums.Team.OrderByStats.PointsPerRound => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.PointsPerRound) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.PointsPerRound),
                Domain.Enums.Team.OrderByStats.GrandTichuCallsWonPercentage => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.GrandTichuCallsWonPercentage) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.GrandTichuCallsWonPercentage),
                Domain.Enums.Team.OrderByStats.TichuCallsWonPercentage => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.TichuCallsWonPercentage) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.TichuCallsWonPercentage),
                Domain.Enums.Team.OrderByStats.HighCardsPerRound => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.HighCardsPerRound) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.HighCardsPerRound),
                Domain.Enums.Team.OrderByStats.OpponentsHighCardsPerRound => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.OpponentsHighCardsPerRound) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.OpponentsHighCardsPerRound),
                Domain.Enums.Team.OrderByStats.BombsPerRound => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.BombsPerRound) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.BombsPerRound),
                Domain.Enums.Team.OrderByStats.OpponentsBombsPerRound => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.TeamStats.OpponentsBombsPerRound) :
                    TeamsWithStatsNoTracking.OrderByDescending(x => x.TeamStats.OpponentsBombsPerRound),
                _ => sortAsc ? TeamsWithStatsNoTracking.OrderBy(x => x.Name) :
                TeamsWithStatsNoTracking.OrderByDescending(x => x.Name),
            };
            return await sortedTeams.PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
