using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei Team's stats object and persists the changes in the database. Returns the resulting Team With Stats Data Transfer Object.
    /// </summary>
    public class UpdateTeamStatsCommand : IRequest<TeamWithStatsDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei Team whose stats will be updated.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Team's Elo rating. Elo is a ranking used to compare teams' and Teams' proficiency.
        /// </summary>
        public int? EloRating { get; set; }
        /// <summary>
        /// The total games the Team has played.
        /// </summary>
        public long? GamesTotal { get; set; }
        /// <summary>
        /// The total games the Team has won.
        /// </summary>
        public long? GamesWon { get; set; }

        /// <summary>
        /// The total number of rounds this Team has played.
        /// </summary>
        public long? RoundsTotal { get; set; }

        /// <summary>
        /// The total rounds the Team has drawn.
        /// </summary>
        public long? RoundsDrawn { get; set; }
        /// <summary>
        /// The total rounds the Team has won.
        /// </summary>
        public long? RoundsWon { get; set; }

        /// <summary>
        /// The total points the Team has won.
        /// </summary>
        public long? PointsWon { get; set; }

        /// <summary>
        /// The total number of Grand Tichu calls this Team has made.
        /// </summary>
        public long? GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this Team has won.
        /// </summary>
        public long? GrandTichuCallsWon { get; set; }

        /// <summary>
        /// The total number of Tichu calls this Team has made.
        /// </summary>
        public long? TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this Team has won.
        /// </summary>
        public long? TichuCallsWon { get; set; }

        /// <summary>
        /// The total number of High Cards the Team's teams had in their games.
        /// </summary>
        public long? HighCardsTotal { get; set; }

        /// <summary>
        /// The total number of High Cards the Team's opponents had in their games.
        /// </summary>
        public long? OpponentsHighCardsTotal { get; set; }

        /// <summary>
        /// The total number of Bombs the Team's teams had in their games.
        /// </summary>
        public long? BombsTotal { get; set; }

        /// <summary>
        /// The total number of Bombs the Team's opponents had in their games.
        /// </summary>
        public long? OpponentsBombsTotal { get; set; }

    }

    public class UpdateTeamStatsCommandHandler : IRequestHandler<UpdateTeamStatsCommand, TeamWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTeamStatsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TeamWithStatsDTO> Handle(UpdateTeamStatsCommand request, CancellationToken cancellationToken)
        {

            Team tm = await _context.Teams.Where(ch => ch.TeamId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            TeamStats tmStats = tm.Stats;
            tmStats = new TeamStats
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
                Team = tmStats.Team,
                TeamId = tmStats.TeamId
            };

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TeamWithStatsDTO>(tm);
        }
    }
}