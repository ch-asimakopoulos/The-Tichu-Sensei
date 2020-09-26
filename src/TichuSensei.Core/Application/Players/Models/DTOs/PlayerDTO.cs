using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;
using System;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    /// <summary>
    /// A Player Data Transfer Object. It does not include the player's statistics.
    /// </summary>
    public class PlayerDTO : IMapFrom<Player>
    {
        public string PlayerId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string AvatarPath { get; set; }
    }
}