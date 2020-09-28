using System;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Models.DTOs
{
    /// <summary>
    /// A Player Data Transfer Object. It does not include the player's statistics.
    /// </summary>
    public class PlayerDTO : IMapFrom<Player>
    {
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public string PlayerId { get; set; }
        /// <summary>
        /// The application's user that is linked to this player.
        /// </summary>
        public string UserId { get; set; }
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
    }
}