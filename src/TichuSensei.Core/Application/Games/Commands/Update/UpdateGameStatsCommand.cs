using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei Game's stats object and persists the changes in the database. Returns the resulting Game With Stats Data Transfer Object.
    /// </summary>
    public class UpdateGameStatsCommand : IRequest<GameWithStatsDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei Game whose stats will be updated.
        /// </summary>
        public long Id { get; set; }


    }

    public class UpdateGameStatsCommandHandler : IRequestHandler<UpdateGameStatsCommand, GameWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGameStatsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GameWithStatsDTO> Handle(UpdateGameStatsCommand request, CancellationToken cancellationToken)
        {

            Game tm = await _context.Games.Where(ch => ch.GameId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            GameStats tmStats = tm.Stats;
            tmStats = new GameStats
            {
                BombsTotal = request.BombsTotal ?? tmStats.BombsTotal,
                EloRating = request.EloRating ?? tmStats.EloRating,
                GamesTotal = request.GamesTotal ?? tmStats.GamesTotal,
                GamesWon = request.GamesWon ?? tmStats.GamesWon,
                GrandTichuCallsTotal = request.GrandTichuCallsTotal ?? tmStats.GrandTichuCallsTotal,
                GrandTichuCallsWon = request.GrandTichuCallsWon ?? tmStats.GrandTichuCallsWon,
                HighCardsTotal = request.HighCardsTotal ?? tmStats.HighCardsTotal,
                OpponentsHighCardsTotal = request.OpponentsHighCardsTotal ?? tmStats.OpponentsHighCardsTotal,
                OpponentsBombsTotal = request.OpponentsBombsTotal ?? tmStats.OpponentsBombsTotal,
                TichuCallsWon = request.TichuCallsWon ?? tmStats.TichuCallsWon,
                RoundsTotal = request.RoundsTotal ?? tmStats.RoundsTotal,
                RoundsDrawn = request.RoundsDrawn ?? tmStats.RoundsDrawn,
                RoundsWon = request.RoundsWon ?? tmStats.RoundsWon,
                PointsWon = request.PointsWon ?? tmStats.PointsWon,
                TichuCallsTotal = request.TichuCallsTotal ?? tmStats.TichuCallsTotal,
                Id = tmStats.Id,
                Game = tmStats.Game,
                GameId = tmStats.GameId
            };

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GameWithStatsDTO>(tm);
        }
    }
}