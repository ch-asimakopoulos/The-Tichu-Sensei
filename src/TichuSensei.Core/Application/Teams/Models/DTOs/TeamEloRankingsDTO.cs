using System;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Models.DTOs
{
    /// <summary>
    /// A Team Elo Rankings Data Transfer Object. It does not include the Team's statistics apart from the Elo Rankings.
    /// </summary>
    public class TeamEloRankingsDTO : IMapFrom<Team>
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
        /// The player elo rankings data transfer object corresponding to the first player of the team. 
        /// </summary>
        public PlayerEloRankingsDTO PlayerOneEloRankings { get; set; }
        /// <summary>
        /// The player elo rankings data transfer object corresponding to the second player of the team.
        /// </summary>
        public PlayerEloRankingsDTO PlayerTwoEloRankings { get; set; }
        /// <summary>
        /// The Team's Elo ranking related stats.
        /// </summary>
        public TeamEloStatsDTO TeamEloRankings { get; set; }

    }

    /// <summary>
    /// This class has all the Team statistics that are related to the Team's Elo ranking.
    /// </summary>
    public class TeamEloStatsDTO : IMapFrom<TeamStats>
    {
        /// <summary>
        /// The Team's Elo rating. Elo is a ranking used to compare players' and teams' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The percentage of Games the Team has won.
        /// </summary>
        public decimal GamesWonPercentage => Math.Round(d: GamesWon / GamesTotal, 4) * 100;
        /// <summary>
        /// The percentage of Games the Team has won as a text.
        /// </summary>
        public string GamesWonPercentageText => $"{GamesWonPercentage}%";
        /// <summary>
        /// The total games the Team has played.
        /// </summary>
        private long GamesTotal { get; set; }
        /// <summary>
        /// The total games the Team has won.
        /// </summary>
        private long GamesWon { get; set; }
    }
}
