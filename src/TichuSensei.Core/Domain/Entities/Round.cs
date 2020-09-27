using System;
using System.Collections.Generic;

namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// A round of a game of Tichu.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public string RoundId { get; set; }
        /// <summary>
        /// The date and time this round started.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date and time this round ended. Value can be null if the round is still in progress.
        /// </summary>
        public DateTime? DateEnded { get; set; }
        /// <summary>
        /// The unique id of the first team playing in this round.
        /// </summary>
        public string TeamOneId { get; set; }
        /// <summary>
        /// The team object of the first team playing in this round. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team TeamOne { get; set; }
        /// <summary>
        /// The unique id of the second team playing in this round.
        /// </summary>
        public string TeamTwoId { get; set; }
        /// <summary>
        /// The team object of the second team playing in this round. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team TeamTwo { get; set; }
        /// <summary>
        /// The unique id of the first player playing in this round.
        /// </summary>
        public string PlayerOneId { get; set; }
        /// <summary>
        /// The player object of the first player playing in this round.
        /// </summary>
        public Player PlayerOne { get; set; }
        /// <summary>
        /// The unique id of the second player playing in this round.
        /// </summary>
        public string PlayerTwoId { get; set; }
        /// <summary>
        /// The player object of the second player playing in this round.
        /// </summary>
        public Player PlayerTwo { get; set; }
        /// <summary>
        /// The unique id of the third player playing in this round.
        /// </summary>
        public string PlayerThreeId { get; set; }
        /// <summary>
        /// The player object of the third player playing in this round.
        /// </summary>
        public Player PlayerThree { get; set; }
        /// <summary>
        /// The unique id of the fourth player playing in this round.
        /// </summary>
        public string PlayerFourId { get; set; }
        /// <summary>
        /// The player object of the fourth player playing in this round.
        /// </summary>
        public Player PlayerFour { get; set; }
        /// <summary>
        /// A collection of all the Tichu or Grand Tichu calls made in this round.
        /// </summary>
        public ICollection<Call> Calls { get; set; }
        /// <summary>
        /// The points the first team won in this round.
        /// </summary>
        public int ScoreTeamOne { get; set; }
        /// <summary>
        /// The points the second team won in this round.
        /// </summary>
        public int ScoreTeamTwo { get; set; }
        /// <summary>
        /// The total high cards the first team had in its possesion in this round.
        /// </summary>
        public int HighCardsTeamOne { get; set; }
        /// <summary>
        /// The total high cards the second team had in its possesion in this round.
        /// </summary>
        public int HighCardsTeamTwo { get; set; }
        /// <summary>
        /// The total number of bombs the first team had in its possesion in this round.
        /// </summary>
        public int BombsTeamOne { get; set; }
        /// <summary>
        /// The total number of bombs the second team had in its possesion in this round.
        /// </summary>
        public int BombsTeamTwo { get; set; }

    }
}
