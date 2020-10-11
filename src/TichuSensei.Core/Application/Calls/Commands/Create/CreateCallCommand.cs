using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Calls.Commands.Create
{
    /// <summary>
    /// Creates a Tichu Sensei call object and persists it in the database. Returns the resulting Call Data Transfer Object.
    /// </summary>
    public class CreateCallCommand : IRequest<CallDTO>
    {

        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular player.      
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The type of this call. Can be Tichu, Grand Tichu or None.
        /// </summary>
        public Domain.Enums.TichuCallType callType { get; set; }

        /// <summary>
        /// The unique Id of the player who made this call.
        /// </summary>
        public long PlayerId { get; set; }

        /// <summary>
        /// The unique Id of the team who made this call.
        /// </summary>
        public long TeamId { get; set; }

        /// <summary>
        /// The unique Id of the round in which this call happened.
        /// </summary>
        public long RoundId { get; set; }

        /// <summary>
        /// Determines whether the call was successful, failed or is null when the call Type is None.
        /// </summary>
        public bool? Success { get; set; }
    }

    public class CreateCallCommandHandler : IRequestHandler<CreateCallCommand, CallDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCallCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CallDTO> Handle(CreateCallCommand request, CancellationToken cancellationToken)
        {
            Call cl = new Call
            {
                CallType = request.callType,
                PlayerId = request.PlayerId,
                RoundId = request.RoundId,
                Success = request.Success,
                TeamId = request.TeamId
            };
            _context.Calls.Add(cl);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CallDTO>(cl);
        }
    }
}