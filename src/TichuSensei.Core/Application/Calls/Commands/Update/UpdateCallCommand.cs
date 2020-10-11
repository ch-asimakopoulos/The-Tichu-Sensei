using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Calls.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei call object and persists it in the database. Returns the resulting Call Data Transfer Object.
    /// </summary>
    public class UpdateCallCommand : IRequest<CallDTO>
    {

        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular player.      
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// This call's unique Id.
        /// </summary>
        public long CallId { get; set; }

        /// <summary>
        /// The type of this call. Can be Tichu, Grand Tichu or None.
        /// </summary>
        public Domain.Enums.TichuCallType? callType { get; set; }

        /// <summary>
        /// Determines whether the call was successful, failed or is null when the call Type is None.
        /// </summary>
        public bool? Success { get; set; }
    }

    public class UpdateCallCommandHandler : IRequestHandler<UpdateCallCommand, CallDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCallCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CallDTO> Handle(UpdateCallCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Call cl = _context.Calls.Where(c => c.CallId == request.CallId).FirstOrDefault();
            cl.CallType = request.callType ?? cl.CallType;
            cl.Success = request.Success;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CallDTO>(cl);
        }
    }
}