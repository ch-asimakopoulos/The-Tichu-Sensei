using System;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    /// <summary>
    /// A Player Data Transfer Object including the player's statistics.
    /// </summary>
    public class PlayerWithStatsDTO : IMapFrom<Player>
    {
        public long PlayerId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string AvatarPath { get; set; }
        public PlayerStatsDTO PlayerStats { get; set; }

    }

    /// <summary>
    /// A player's statistics Data Transfer Object.
    /// </summary>
    public class PlayerStatsDTO : IMapFrom<PlayerStats>
    {
        /// <summary>
        /// The player's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The total games the player has played.
        /// </summary>
        public long GamesTotal { get; set; }
        /// <summary>
        /// The total games the player has won.
        /// </summary>
        public long GamesWon { get; set; }

        /// <summary>
        /// The percentage of Games the player has won.
        /// </summary>
        public decimal GamesWonPercentage => Math.Round(d: GamesWon / GamesTotal, 4) * 100;

        /// <summary>
        /// The percentage of Games the player has won as a text.
        /// </summary>
        public string GamesWonPercentageText => $"{GamesWonPercentage}%";

        /// <summary>
        /// The total number of rounds this player has played.
        /// </summary>
        public long RoundsTotal { get; set; }

        /// <summary>
        /// The total rounds the player has drawn.
        /// </summary>
        public long RoundsDrawn { get; set; }
        /// <summary>
        /// The total rounds the player has won.
        /// </summary>
        public long RoundsWon { get; set; }
        /// <summary>
        /// The percentage of Rounds the player has won.
        /// </summary>
        public decimal RoundsWonPercentage => Math.Round(d: RoundsWon / RoundsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Rounds the player has won as a text.
        /// </summary>
        public string RoundsWonPercentageText => $"{RoundsWonPercentage}%";
        /// <summary>
        /// The total points the player has won.
        /// </summary>
        public long PointsWon { get; set; }
        /// <summary>
        /// The points per round that the player won.
        /// </summary>
        public decimal PointsPerRound => Math.Round(d: PointsWon / RoundsTotal, 4);
        /// <summary>
        /// The total number of Grand Tichu calls this player has made.
        /// </summary>
        public long GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this player has won.
        /// </summary>
        public long GrandTichuCallsWon { get; set; }
        /// <summary>
        /// The percentage of Grand Tichus the player has called and succeeded.
        /// </summary>
        public decimal GrandTichuCallsWonPercentage => Math.Round(d: GrandTichuCallsWon / GrandTichuCallsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Grand Tichus the player has called and succeeded as a text.
        /// </summary>
        public string GrandTichuCallsWonPercentageText => $"{GrandTichuCallsWonPercentage}%";
        /// <summary>
        /// The total number of Tichu calls this player has made.
        /// </summary>
        public long TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this player has won.
        /// </summary>
        public long TichuCallsWon { get; set; }
        /// <summary>
        /// The percentage of Tichus the player has called and succeeded.
        /// </summary>
        public decimal TichuCallsWonPercentage => Math.Round(d: TichuCallsWon / TichuCallsTotal, 4) * 100;

        /// <summary>
        /// The percentage of Tichus the player has called and succeeded as a text.
        /// </summary>
        public string TichuCallWonPercentageText => $"{TichuCallsWonPercentage}%";
        /// <summary>
        /// The total number of High Cards the player's teams had in their games.
        /// </summary>
        public long HighCardsTotal { get; set; }
        /// <summary>
        /// The high cards per round that the player's teams had.
        /// </summary>
        public decimal HighCardsPerRound => Math.Round(d: HighCardsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of High Cards the player's opponents had in their games.
        /// </summary>
        public long OpponentsHighCardsTotal { get; set; }
        /// <summary>
        /// The high cards per round that the player's opponents had.
        /// </summary>
        public decimal OpponentsHighCardsPerRound => Math.Round(d: OpponentsHighCardsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of Bombs the player's teams had in their games.
        /// </summary>
        public long BombsTotal { get; set; }
        /// <summary>
        /// The bombs per round that the player's teams had.
        /// </summary>
        public decimal BombsPerRound => Math.Round(d: BombsTotal / RoundsTotal, 4);
        /// <summary>
        /// The total number of Bombs the player's opponents had in their games.
        /// </summary>
        public long OpponentsBombsTotal { get; set; }
        /// <summary>
        /// The bombs per round that the player's opponents had.
        /// </summary>
        public decimal OpponentsBombsPerRound => Math.Round(d: OpponentsBombsTotal / RoundsTotal, 4);
    }
}