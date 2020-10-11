using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Calls.Queries
{
    /// <summary>
    /// Returns a Call specified by its unique Id.
    /// </summary>
    public class GetCallQuery : IRequest<CallDTO>
    {
        public long id;

    }

    public class GetCallQueryHandler : IRequestHandler<GetCallQuery, CallDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCallQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CallDTO> Handle(GetCallQuery request, CancellationToken cancellationToken)
        {
            return await _context.Calls.AsNoTracking().Where(ch => ch.CallId == request.id)
                .ProjectTo<CallDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}

