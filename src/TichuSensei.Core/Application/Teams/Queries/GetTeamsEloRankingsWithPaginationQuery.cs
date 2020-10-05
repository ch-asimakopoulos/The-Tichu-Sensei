using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Teams.Queries
{
    /// <summary>
    /// Returns a portion of the total Teams including their Elo rankings using Pagination. The page number, page size and order direction can be specified. Ordering will be done by Elo ranking.
    /// </summary>
    public class GetTeamsEloRankingsWithPaginationQuery : IRequest<PaginatedList<TeamEloRankingsDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

    }

    public class GetTeamsEloRankingsWithPaginationQueryHandler : IRequestHandler<GetTeamsEloRankingsWithPaginationQuery, PaginatedList<TeamEloRankingsDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamsEloRankingsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TeamEloRankingsDTO>> Handle(GetTeamsEloRankingsWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<Domain.Entities.Team> EloEligibleTeams = _context.Teams.AsNoTracking().Where(EloEligible);

            IOrderedQueryable<Domain.Entities.Team> SortedEloEligibleTeams = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending) ? EloEligibleTeams
               .OrderBy(x => x.Stats.EloRating) : EloEligibleTeams
               .OrderByDescending(x => x.Stats.EloRating);

            return await SortedEloEligibleTeams.ProjectTo<TeamEloRankingsDTO>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }

        private readonly Expression<System.Func<Domain.Entities.Team, bool>> EloEligible = pl => pl.Stats.GamesTotal >= Kernel.Consts.Elo.MinGamesForEligibility;

    }
}
