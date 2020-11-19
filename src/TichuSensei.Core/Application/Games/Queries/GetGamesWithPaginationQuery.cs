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
    /// Returns a portion of the total Games using Pagination. The page number, page size and order direction can be specified. Ordering will be done by id.
    /// </summary>
    public class GetGamesWithPaginationQuery : IRequest<PaginatedList<GameDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

    }

    public class GetGamesWithPaginationQueryHandler : IRequestHandler<GetGamesWithPaginationQuery, PaginatedList<GameDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGamesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GameDTO>> Handle(GetGamesWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<GameDTO> GamesNoTracking = _context.Games.AsNoTracking().ProjectTo<GameDTO>(_mapper.ConfigurationProvider);
            IOrderedQueryable<GameDTO> sortedGames;
            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);

                sortedGames = sortAsc ? GamesNoTracking.OrderBy(x => x.GameId) :
                        GamesNoTracking.OrderByDescending(x => x.GameId);
            
            return await sortedGames.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

