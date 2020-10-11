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
    /// Returns a portion of the total Teams using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetTeamsWithPaginationQuery : IRequest<PaginatedList<TeamDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

        public Domain.Enums.Team.OrderBy OrderBy = Domain.Enums.Team.OrderBy.Name;
    }

    public class GetTeamsWithPaginationQueryHandler : IRequestHandler<GetTeamsWithPaginationQuery, PaginatedList<TeamDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<TeamDTO>> Handle(GetTeamsWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<TeamDTO> TeamsNoTracking = _context.Teams.AsNoTracking().ProjectTo<TeamDTO>(_mapper.ConfigurationProvider);
            IOrderedQueryable<TeamDTO> sortedTeams;
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);

            if (request.OrderBy.Equals(Domain.Enums.Team.OrderBy.DateCreated))
            {
                sortedTeams = sortAsc ? TeamsNoTracking.OrderBy(x => x.DateCreated) :
                        TeamsNoTracking.OrderByDescending(x => x.DateCreated);
            }
            else
            {
                sortedTeams = sortAsc ? TeamsNoTracking.OrderBy(x => x.Name) :
                        TeamsNoTracking.OrderByDescending(x => x.Name);
            }

            return await sortedTeams.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

