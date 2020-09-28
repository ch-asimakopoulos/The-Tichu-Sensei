using System;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    /// <summary>
    /// A Player Elo Rankings Data Transfer Object. It does not include the player's statistics apart from the Elo Rankings.
    /// </summary>
    public class PlayerEloRankingsDTO : IMapFrom<Player>
    {
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public string PlayerId { get; set; }
        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date and time the player got created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The link to the user's avatar image.
        /// </summary>
        public string AvatarPath { get; set; }
        /// <summary>
        /// The player's Elo ranking related stats.
        /// </summary>
        public PlayerEloStatsDTO PlayerEloRankings { get; set; }

    }

    /// <summary>
    /// This class has all the player statistics that are related to the player's Elo ranking.
    /// </summary>
    public class PlayerEloStatsDTO : IMapFrom<PlayerStats>
    {
        /// <summary>
        /// The player's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The percentage of Games the player has won.
        /// </summary>
        public decimal GamesWonPercentage => Math.Round(d: GamesWon / GamesTotal, 4) * 100;
        /// <summary>
        /// The percentage of Games the player has won as a text.
        /// </summary>
        public string GamesWonPercentageText => $"{GamesWonPercentage}%";
        /// <summary>
        /// The total games the player has played.
        /// </summary>
        private long GamesTotal { get; set; }
        /// <summary>
        /// The total games the player has won.
        /// </summary>
        private long GamesWon { get; set; }
    }
}
