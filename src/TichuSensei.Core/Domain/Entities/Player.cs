using System;


namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// A Tichu player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The unique Id.
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
        /// <summary>
        /// The player's statistics. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual PlayerStats Stats { get; set; }
    }

}
