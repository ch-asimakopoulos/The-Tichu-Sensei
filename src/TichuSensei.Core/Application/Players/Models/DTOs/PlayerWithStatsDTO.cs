using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;
using System;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    /// <summary>
    /// A Player Data Transfer Object including the player's statistics.
    /// </summary>
    public class PlayerWithStatsDTO : IMapFrom<Player>
    {
        public string PlayerId { get; set; }
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
        public int EloRating { get; set; }
        public int GamesTotal { get; set; }
        public int GamesWon { get; set; }
        public int RoundsTotal { get; set; }
        public int RoundsDrawn { get; set; }
        public int RoundsWon { get; set; }
        public int PointsWon { get; set; }
        public int GrandTichuCallsTotal { get; set; }
        public int GrandTichuCallsWon { get; set; }
        public int TichuCallsTotal { get; set; }
        public int TichuCallsWon { get; set; }
        public int HighCardsTotal { get; set; }
        public int OpponentsHighCardsTotal { get; set; }
        public int BombsTotal { get; set; }
        public int OpponentsBombsTotal { get; set; }
    }
}