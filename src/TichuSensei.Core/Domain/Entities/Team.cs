using System;


namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// A Tichu team consisting of two players.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// The team's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date and time when the team was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The unique Id of the first player of the team.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// The player object corresponding to the first player of the team. 
        /// </summary>
        public Player PlayerOne { get; set; }
        /// <summary>
        /// The unique Id of the second player of the team.
        /// </summary>
        public long PlayerTwoId { get; set; }
        /// <summary>
        /// The player object corresponding to the second player of the team.
        /// </summary>
        public Player PlayerTwo { get; set; }
        /// <summary>
        /// The team's statistics. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual TeamStats Stats { get; set; }
    }
}
