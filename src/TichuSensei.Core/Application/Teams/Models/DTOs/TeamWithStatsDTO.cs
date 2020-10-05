using System;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Models.DTOs
{
    /// <summary>
    /// A Team Data Transfer Object including the Team's statistics.
    /// </summary>
    public class TeamWithStatsDTO : IMapFrom<Team>
    {
        /// <summary>
        /// The Team's unique Id.
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// The Team's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date and time the Team got created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The player data transfer object corresponding to the first player of the team including his statistics. 
        /// </summary>
        public PlayerStatsDTO PlayerOneWithStats { get; set; }
        /// <summary>
        /// The player data transfer object corresponding to the second player of the team including his statistics.
        /// </summary>
        public PlayerDTO PlayerTwoWithStats { get; set; }
        public TeamStatsDTO TeamStats { get; set; }

    }

    /// <summary>
    /// A Team's statistics Data Transfer Object.
    /// </summary>
    public class TeamStatsDTO : IMapFrom<TeamStats>
    {
        /// <summary>
        /// The Team's Elo rating. Elo is a ranking used to compare teams and teams' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The total games the Team has played.
        /// </summary>
        public long GamesTotal { get; set; }
        /// <summary>
        /// The total games the Team has won.
        /// </summary>
        public long GamesWon { get; set; }

        /// <summary>
        /// The percentage of Games the Team has won.
        /// </summary>
        public decimal GamesWonPercentage => Math.Round(d: GamesWon / GamesTotal, 4) * 100;

        /// <summary>
        /// The percentage of Games the Team has won as a text.
        /// </summary>
        public string GamesWonPercentageText => $"{GamesWonPercentage}%";

        /// <summary>
        /// The total number of rounds this Team has played.
        /// </summary>
        public long RoundsTotal { get; set; }

        /// <summary>
        /// The total rounds the Team has drawn.
        /// </summary>
        public long RoundsDrawn { get; set; }
        /// <summary>
        /// The total rounds the Team has won.
        /// </summary>
        public long RoundsWon { get; set; }
        /// <summary>
        /// The percentage of Rounds the Team has won.
        /// </summary>
        public decimal RoundsWonPercentage => Math.Round(d: RoundsWon / RoundsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Rounds the Team has won as a text.
        /// </summary>
        public string RoundsWonPercentageText => $"{RoundsWonPercentage}%";
        /// <summary>
        /// The total points the Team has won.
        /// </summary>
        public long PointsWon { get; set; }
        /// <summary>
        /// The points per round that the Team won.
        /// </summary>
        public decimal PointsPerRound => Math.Round(d: PointsWon / RoundsTotal, 4);
        /// <summary>
        /// The total number of Grand Tichu calls this Team has made.
        /// </summary>
        public long GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this Team has won.
        /// </summary>
        public long GrandTichuCallsWon { get; set; }
        /// <summary>
        /// The percentage of Grand Tichus the Team has called and succeeded.
        /// </summary>
        public decimal GrandTichuCallsWonPercentage => Math.Round(d: GrandTichuCallsWon / GrandTichuCallsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Grand Tichus the Team has called and succeeded as a text.
        /// </summary>
        public string GrandTichuCallsWonPercentageText => $"{GrandTichuCallsWonPercentage}%";
        /// <summary>
        /// The total number of Tichu calls this Team has made.
        /// </summary>
        public long TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this Team has won.
        /// </summary>
        public long TichuCallsWon { get; set; }
        /// <summary>
        /// The percentage of Tichus the Team has called and succeeded.
        /// </summary>
        public decimal TichuCallsWonPercentage => Math.Round(d: TichuCallsWon / TichuCallsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Tichus the Team has called and succeeded as a text.
        /// </summary>
        public string TichuCallWonPercentageText => $"{TichuCallsWonPercentage}%";
        /// <summary>
        /// The total number of High Cards the team had in their games.
        /// </summary>
        public long HighCardsTotal { get; set; }
        /// <summary>
        /// The high cards per round that the team had.
        /// </summary>
        public decimal HighCardsPerRound => Math.Round(d: HighCardsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of High Cards the Team's opponents had in their games.
        /// </summary>
        public long OpponentsHighCardsTotal { get; set; }
        /// <summary>
        /// The high cards per round that the Team's opponents had.
        /// </summary>
        public decimal OpponentsHighCardsPerRound => Math.Round(d: OpponentsHighCardsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of Bombs the team had in their games.
        /// </summary>
        public long BombsTotal { get; set; }
        /// <summary>
        /// The bombs per round that the team had.
        /// </summary>
        public decimal BombsPerRound => Math.Round(d: BombsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of Bombs the Team's opponents had in their games.
        /// </summary>
        public long OpponentsBombsTotal { get; set; }
        /// <summary>
        /// The bombs per round that the Team's opponents had.
        /// </summary>
        public decimal OpponentsBombsPerRound => Math.Round(d: OpponentsBombsTotal / RoundsTotal, 4);
    }
}