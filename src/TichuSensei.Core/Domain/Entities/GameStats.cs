using System.Collections.Generic;


namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// The game stats of a Tichu game.
    /// </summary>
    public class GameStats
    {
        /// <summary>
        /// The unique id. 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The total rounds of this game. 
        /// </summary>
        public int RoundsTotal { get; set; }
        /// <summary>
        /// The rounds of this game that team one won. 
        /// </summary>
        public int RoundsWonTeamOne { get; set; }
        /// <summary>
        /// The rounds of this game that team two won. 
        /// </summary>
        public int RoundsWonTeamTwo { get; set; }
        /// <summary>
        /// A collection of round objects describing each round of this game. 
        /// </summary>
        public ICollection<Round> Rounds { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one made in this game. 
        /// </summary>
        public int GrandTichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one won in this game. 
        /// </summary>
        public int GrandTichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two made in this game. 
        /// </summary>
        public int GrandTichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two won in this game. 
        /// </summary>
        public int GrandTichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team one made in this game. 
        /// </summary>
        public int TichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team one won in this game. 
        /// </summary>
        public int TichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team two made in this game. 
        /// </summary>
        public int TichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team two won in this game. 
        /// </summary>
        public int TichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total High Cards team one had in this game. 
        /// </summary>
        public int HighCardsTotalTeamOne { get; set; }
        /// <summary>
        /// The total High Cards team two had in this game. 
        /// </summary>
        public int HighCardsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Bombs team one had in this game. 
        /// </summary>
        public int BombsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Bombs team two had in this game. 
        /// </summary>
        public int BombsTotalTeamTwo { get; set; }
        /// <summary>
        /// The game's unique Id.
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// The game's information. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Game Game { get; set; }

    }
}
