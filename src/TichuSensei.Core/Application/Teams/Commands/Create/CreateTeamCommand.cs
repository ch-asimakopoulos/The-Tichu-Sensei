using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Commands.Create
{
    /// <summary>
    /// Creates a Tichu Sensei Team object and persists it in the database. Returns the resulting Team Data Transfer Object.
    /// </summary>
    public class CreateTeamCommand : IRequest<TeamDTO>
    {
        /// <summary>
        /// Containing the new Team's name.      
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Containing the new Team's player one unique identifier.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// Containing the new Team's player two unique identifier.
        /// </summary>
        public long PlayerTwoId { get; set; }
    }

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTeamCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TeamDTO> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            Team tm = new Team
            {
                DateCreated = DateTime.UtcNow,
                Name = request.Name,
                Stats = new TeamStats
                {
                    BombsTotal = 0,
                    GamesTotal = 0,
                    GamesWon = 0,
                    GrandTichuCallsTotal = 0,
                    GrandTichuCallsWon = 0,
                    EloRating = 0,
                    HighCardsTotal = 0,
                    OpponentsBombsTotal = 0,
                    TichuCallsTotal = 0,
                    TichuCallsWon = 0,
                    OpponentsHighCardsTotal = 0,
                    PointsWon = 0,
                    RoundsDrawn = 0,
                    RoundsTotal = 0,
                    RoundsWon = 0
                },
                PlayerOneId = request.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId
            };
            _context.Teams.Add(tm);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TeamDTO>(tm);
        }
    }
}