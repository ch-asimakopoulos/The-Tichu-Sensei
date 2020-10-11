using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Application.Shared.Models;

namespace TichuSensei.Core.Application.Calls.Queries
{
    /// <summary>
    /// Returns a portion of the total Tichu Calls using Pagination. The page number, page size and order direction can be specified. Ordering will be done by name.
    /// </summary>
    public class GetTichuCallsWithPaginationQuery : IRequest<PaginatedList<CallDTO>>
    {
        public int PageNumber { get; set; } = Kernel.Consts.Pagination.PageNumber.Default;
        public int PageSize { get; set; } = Kernel.Consts.Pagination.PageSize.Default;

        public Kernel.Enums.OrderDirection OrderDirection = Kernel.Enums.OrderDirection.Ascending;

        //public Domain.Enums.Call.OrderBy OrderBy = Domain.Enums.Call.OrderBy.;
    }

    public class GetTichuCallsWithPaginationQueryHandler : IRequestHandler<GetTichuCallsWithPaginationQuery, PaginatedList<CallDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTichuCallsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CallDTO>> Handle(GetTichuCallsWithPaginationQuery request, CancellationToken cancellationToken)
        {

            IQueryable<CallDTO> CallsNoTracking = _context.Calls.AsNoTracking().Where(cl => Domain.Enums.TichuCallType.Tichu == cl.CallType).ProjectTo<CallDTO>(_mapper.ConfigurationProvider);
            IOrderedQueryable<CallDTO> sortedCalls;

            bool sortAsc = request.OrderDirection.Equals(Kernel.Enums.OrderDirection.Ascending);
            sortedCalls = sortAsc ? CallsNoTracking.OrderBy(cl => cl.CallId) : CallsNoTracking.OrderByDescending(cl => cl.CallId);
            return await sortedCalls.PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

