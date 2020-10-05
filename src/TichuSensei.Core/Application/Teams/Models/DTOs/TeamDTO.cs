using System;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Models.DTOs
{
    /// <summary>
    /// A Team Data Transfer Object. It does not include the Team's statistics.
    /// </summary>
    public class TeamDTO : IMapFrom<Team>
    {
        /// <summary>
        /// The Team's unique Id.
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// The Team's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date and time the Team got created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The player data transfer object corresponding to the first player of the team. 
        /// </summary>
        public PlayerDTO PlayerOne { get; set; }
        /// <summary>
        /// The player data transfer object corresponding to the second player of the team.
        /// </summary>
        public PlayerDTO PlayerTwo { get; set; }
    }
}