using System.Collections.Generic;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// The game stats of a Tichu game.
    /// </summary>
    public class GameStats : TrackingChangesEntity
    {
        /// <summary>
        /// The unique id. 
        /// </summary>
        public long Id { get; set; }
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
        /// A collection of round objects describing each round of this game. 
        /// </summary>
        public ICollection<Round> Rounds { get; set; }
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
        /// <summary>
        /// The game's information. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Game Game { get; set; }

    }
}
