using System;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Models.DTOs
{
    /// <summary>
    /// A Game Data Transfer Object. It does not include the Game's statistics.
    /// </summary>
    public class GameDTO : IMapFrom<Game>
    {
        /// <summary>
        /// The Game's unique Id.
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
        /// The unique id of the first team playing in this game.
        /// </summary>
        public long TeamOneId { get; set; }
        /// <summary>
        /// The unique id of the second team playing in this game.
        /// </summary>
        public long TeamTwoId { get; set; }
        /// <summary>
        /// The unique id of the first player playing in this round.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// The unique id of the second player playing in this game.
        /// </summary>
        public long PlayerTwoId { get; set; }
        /// <summary>
        /// The unique id of the third player playing in this game.
        /// </summary>
        public long PlayerThreeId { get; set; }
        /// <summary>
        /// The unique id of the fourth player playing in this game.
        /// </summary>
        public long PlayerFourId { get; set; }
    }
}