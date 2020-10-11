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
    /// Returns a portion of the total players using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetPlayersWithPaginationQuery : IRequest<PaginatedList<PlayerDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

        public Domain.Enums.Player.OrderBy OrderBy = Domain.Enums.Player.OrderBy.Name;
    }

    public class GetPlayersWithPaginationQueryHandler : IRequestHandler<GetPlayersWithPaginationQuery, PaginatedList<PlayerDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PlayerDTO>> Handle(GetPlayersWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<PlayerDTO> playersNoTracking = _context.Players.AsNoTracking().ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider);
            IOrderedQueryable<PlayerDTO> sortedPlayers;
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);

            if (request.OrderBy.Equals(Domain.Enums.Player.OrderBy.DateCreated))
            {
                sortedPlayers = sortAsc ? playersNoTracking.OrderBy(x => x.DateCreated) :
                        playersNoTracking.OrderByDescending(x => x.DateCreated);
            }
            else
            {
                sortedPlayers = sortAsc ? playersNoTracking.OrderBy(x => x.Name) :
                        playersNoTracking.OrderByDescending(x => x.Name);
            }

            return await sortedPlayers.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

