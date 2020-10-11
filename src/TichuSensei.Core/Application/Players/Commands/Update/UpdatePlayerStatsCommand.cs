using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei player's stats object and persists the changes in the database. Returns the resulting Player With Stats Data Transfer Object.
    /// </summary>
    public class UpdatePlayerStatsCommand : IRequest<PlayerWithStatsDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei player whose stats will be updated.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The player's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int? EloRating { get; set; }
        /// <summary>
        /// The total games the player has played.
        /// </summary>
        public long? GamesTotal { get; set; }
        /// <summary>
        /// The total games the player has won.
        /// </summary>
        public long? GamesWon { get; set; }

        /// <summary>
        /// The total number of rounds this player has played.
        /// </summary>
        public long? RoundsTotal { get; set; }

        /// <summary>
        /// The total rounds the player has drawn.
        /// </summary>
        public long? RoundsDrawn { get; set; }
        /// <summary>
        /// The total rounds the player has won.
        /// </summary>
        public long? RoundsWon { get; set; }

        /// <summary>
        /// The total points the player has won.
        /// </summary>
        public long? PointsWon { get; set; }

        /// <summary>
        /// The total number of Grand Tichu calls this player has made.
        /// </summary>
        public long? GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this player has won.
        /// </summary>
        public long? GrandTichuCallsWon { get; set; }

        /// <summary>
        /// The total number of Tichu calls this player has made.
        /// </summary>
        public long? TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this player has won.
        /// </summary>
        public long? TichuCallsWon { get; set; }

        /// <summary>
        /// The total number of High Cards the player's teams had in their games.
        /// </summary>
        public long? HighCardsTotal { get; set; }

        /// <summary>
        /// The total number of High Cards the player's opponents had in their games.
        /// </summary>
        public long? OpponentsHighCardsTotal { get; set; }

        /// <summary>
        /// The total number of Bombs the player's teams had in their games.
        /// </summary>
        public long? BombsTotal { get; set; }

        /// <summary>
        /// The total number of Bombs the player's opponents had in their games.
        /// </summary>
        public long? OpponentsBombsTotal { get; set; }

    }

    public class UpdatePlayerStatsCommandHandler : IRequestHandler<UpdatePlayerStatsCommand, PlayerWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePlayerStatsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlayerWithStatsDTO> Handle(UpdatePlayerStatsCommand request, CancellationToken cancellationToken)
        {

            Player pl = await _context.Players.Where(ch => ch.PlayerId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            PlayerStats plStats = pl.Stats;
            plStats = new PlayerStats
            {
                BombsTotal = request.BombsTotal ?? plStats.BombsTotal,
                EloRating = request.EloRating ?? plStats.EloRating,
                GamesTotal = request.GamesTotal ?? plStats.GamesTotal,
                GamesWon = request.GamesWon ?? plStats.GamesWon,
                GrandTichuCallsTotal = request.GrandTichuCallsTotal ?? plStats.GrandTichuCallsTotal,
                GrandTichuCallsWon = request.GrandTichuCallsWon ?? plStats.GrandTichuCallsWon,
                HighCardsTotal = request.HighCardsTotal ?? plStats.HighCardsTotal,
                OpponentsHighCardsTotal = request.OpponentsHighCardsTotal ?? plStats.OpponentsHighCardsTotal,
                OpponentsBombsTotal = request.OpponentsBombsTotal ?? plStats.OpponentsBombsTotal,
                TichuCallsWon = request.TichuCallsWon ?? plStats.TichuCallsWon,
                RoundsTotal = request.RoundsTotal ?? plStats.RoundsTotal,
                RoundsDrawn = request.RoundsDrawn ?? plStats.RoundsDrawn,
                RoundsWon = request.RoundsWon ?? plStats.RoundsWon,
                PointsWon = request.PointsWon ?? plStats.PointsWon,
                TichuCallsTotal = request.TichuCallsTotal ?? plStats.TichuCallsTotal,
                Id = plStats.Id,
                Player = plStats.Player,
                PlayerId = plStats.PlayerId
            };

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PlayerWithStatsDTO>(pl);
        }
    }
}