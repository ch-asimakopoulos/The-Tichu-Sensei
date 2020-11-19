using System;
using System.Collections.Generic;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Rounds.Models.DTOs
{
    /// <summary>
    /// A Round Data Transfer Object. It does not include the team and player's statistics.
    /// </summary>
    public class RoundDTO : IMapFrom<Round>
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public long RoundId { get; set; }
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
        public long TeamOneId { get; set; }
        /// <summary>
        /// The unique id of the second team playing in this round.
        /// </summary>
        public long TeamTwoId { get; set; }
        /// <summary>
        /// The unique id of the first player playing in this round.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// The unique id of the second player playing in this round.
        /// </summary>
        public long PlayerTwoId { get; set; }
        /// <summary>
        /// The unique id of the third player playing in this round.
        /// </summary>
        public long PlayerThreeId { get; set; }
        /// <summary>
        /// The unique id of the fourth player playing in this round.
        /// </summary>
        public long PlayerFourId { get; set; }
        /// <summary>
        /// A collection of all the Tichu or Grand Tichu calls made in this round.
        /// </summary>
        public IList<CallDTO> Calls { get; set; }
        /// <summary>
        /// The points the first team won in this round.
        /// </summary>
        public long ScoreTeamOne { get; set; }
        /// <summary>
        /// The points the second team won in this round.
        /// </summary>
        public long ScoreTeamTwo { get; set; }
        /// <summary>
        /// The total high cards the first team had in its possesion in this round.
        /// </summary>
        public long HighCardsTeamOne { get; set; }
        /// <summary>
        /// The total high cards the second team had in its possesion in this round.
        /// </summary>
        public long HighCardsTeamTwo { get; set; }
        /// <summary>
        /// The total number of bombs the first team had in its possesion in this round.
        /// </summary>
        public long BombsTeamOne { get; set; }
        /// <summary>
        /// The total number of bombs the second team had in its possesion in this round.
        /// </summary>
        public long BombsTeamTwo { get; set; }
    }
}