using System;

namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// A Tichu game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public long GameId { get; set; }
        /// <summary>
        /// Mercy Rule setting for this game. Mercy rule states that a game will end if the difference of the teams score exceeds 1000 at any time.
        /// </summary>
        public bool MercyRule { get; set; }
        /// <summary>
        /// States if the game is over, or is still under way.
        /// </summary>
        public bool GameOver { get; set; }
        /// <summary>
        /// The date and time this game started.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date and time this game ended. Value can be null if the game is still in progress.
        /// </summary>
        public DateTime? DateEnded { get; set; }
        /// <summary>
        /// The unique id of the first team playing in this game.
        /// </summary>
        public long TeamOneId { get; set; }
        /// <summary>
        /// The team object of the first team playing in this game. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team TeamOne { get; set; }
        /// <summary>
        /// The unique id of the second team playing in this game.
        /// </summary>
        public long TeamTwoId { get; set; }
        /// <summary>
        /// The team object of the second team playing in this game. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team TeamTwo { get; set; }
        /// <summary>
        /// The unique id of the first player playing in this round.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// The player object of the first player playing in this round.
        /// </summary>
        public Player PlayerOne { get; set; }
        /// <summary>
        /// The unique id of the second player playing in this game.
        /// </summary>
        public long PlayerTwoId { get; set; }
        /// <summary>
        /// The player object of the second player playing in this game.
        /// </summary>
        public Player PlayerTwo { get; set; }
        /// <summary>
        /// The unique id of the third player playing in this game.
        /// </summary>
        public long PlayerThreeId { get; set; }
        /// <summary>
        /// The player object of the third player playing in this game.
        /// </summary>
        public Player PlayerThree { get; set; }
        /// <summary>
        /// The unique id of the fourth player playing in this game.
        /// </summary>
        public long PlayerFourId { get; set; }
        /// <summary>
        /// The player object of the fourth player playing in this game.
        /// </summary>
        public Player PlayerFour { get; set; }


    }
}
