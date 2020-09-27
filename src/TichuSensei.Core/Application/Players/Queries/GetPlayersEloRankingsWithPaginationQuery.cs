using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Players.Queries
{
    /// <summary>
    /// Returns a portion of the total players including their Elo rankings using Pagination. The page number, page size and order direction can be specified. Ordering will be done by Elo ranking.
    /// </summary>
    public class GetPlayersEloRankingsWithPaginationQuery : IRequest<PaginatedList<PlayerEloRankingsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

    }

    public class GetPlayersEloRankingsWithPaginationQueryHandler : IRequestHandler<GetPlayersEloRankingsWithPaginationQuery, PaginatedList<PlayerEloRankingsDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayersEloRankingsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PlayerEloRankingsDTO>> Handle(GetPlayersEloRankingsWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<Domain.Entities.Player> EloEligiblePlayers = _context.Players.AsNoTracking().Where(EloEligible);

            IOrderedQueryable<Domain.Entities.Player> SortedEloEligiblePlayers = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending) ? EloEligiblePlayers
               .OrderBy(x => x.Stats.EloRating) : EloEligiblePlayers
               .OrderByDescending(x => x.Stats.EloRating);

            return await SortedEloEligiblePlayers.ProjectTo<PlayerEloRankingsDTO>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        private readonly Expression<System.Func<Domain.Entities.Player, bool>> EloEligible = pl => pl.Stats.GamesTotal >= Kernel.Consts.Elo.MinGamesForEligibility;

    }
}
