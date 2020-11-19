using System;
using System.Collections.Generic;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Rounds.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Models.DTOs
{
    /// <summary>
    /// A Game Data Transfer Object. It includes the Game's statistics.
    /// </summary>
    public class GameWithStatsDTO : IMapFrom<Game>
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

        public GameStatsDTO GameStatsDTO { get; set; }
    }
    /// <summary>
    /// A game's statistics Data Transfer Object.
    /// </summary>
    public class GameStatsDTO : IMapFrom<GameStats>
    {

        /// <summary>
        /// The unique id. 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The current team one score for this game.
        /// </summary>
        public int ScoreTeamOne { get; set; }

        /// <summary>
        /// The current team two score for this game.
        /// </summary>
        public int ScoreTeamTwo { get; set; }

        /// <summary>
        /// The total rounds of this game. 
        /// </summary>
        public long RoundsTotal { get; set; }
        /// <summary>
        /// The rounds of this game that team one won. 
        /// </summary>
        public long RoundsWonTeamOne { get; set; }
        /// <summary>
        /// The rounds of this game that team two won. 
        /// </summary>
        public long RoundsWonTeamTwo { get; set; }
        /// <summary>
        /// A collection of round data transfer objects describing each round of this game. 
        /// </summary>
        public IList<RoundDTO> Rounds { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one made in this game. 
        /// </summary>
        public long GrandTichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one won in this game. 
        /// </summary>
        public long GrandTichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two made in this game. 
        /// </summary>
        public long GrandTichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two won in this game. 
        /// </summary>
        public long GrandTichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team one made in this game. 
        /// </summary>
        public long TichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team one won in this game. 
        /// </summary>
        public long TichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team two made in this game. 
        /// </summary>
        public long TichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team two won in this game. 
        /// </summary>
        public long TichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total High Cards team one had in this game. 
        /// </summary>
        public long HighCardsTotalTeamOne { get; set; }
        /// <summary>
        /// The total High Cards team two had in this game. 
        /// </summary>
        public long HighCardsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Bombs team one had in this game. 
        /// </summary>
        public long BombsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Bombs team two had in this game. 
        /// </summary>
        public long BombsTotalTeamTwo { get; set; }
        /// <summary>
        /// The game's unique Id.
        /// </summary>
        public long GameId { get; set; }
    }
}