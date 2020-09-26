using System;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    public class PlayerEloRankingsDTO : IMapFrom<Player>
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string AvatarPath { get; set; }
        public PlayerEloStatsDTO PlayerEloRankings { get; set; }

    }

    public class PlayerEloStatsDTO : IMapFrom<PlayerStats>
    {
        public int EloRating { get; set; }
        public decimal GamesWonPercentage => Math.Round(d: GamesWon / GamesTotal, 4) * 100;
        public string GamesWonPercentageText => $"{GamesWonPercentage}%";
        private int GamesTotal { get; set; }
        private int GamesWon { get; set; }
    }
}
