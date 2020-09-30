using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Commands.Create
{
    /// <summary>
    /// Creates a Tichu Sensei player object and persists it in the database. Returns the resulting Player Data Transfer Object.
    /// </summary>
    public class CreatePlayerCommand : IRequest<PlayerDTO>
    {
        /// <summary>
        /// Containing the new player's name.      
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular player.      
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Containing the new player's image URL, if it exists.      
        /// </summary>
        public string URL { get; set; }
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, PlayerDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlayerDTO> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            Player pl = new Player
            {
                DateCreated = DateTime.UtcNow,
                Name = request.Name,
                Stats = new PlayerStats
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
                UserId = request.UserId,
                AvatarPath = request.URL
            };
            _context.Players.Add(pl);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PlayerDTO>(pl);
        }
    }
}