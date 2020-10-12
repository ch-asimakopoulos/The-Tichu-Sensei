using TichuSensei.Core.Application.Shared.Mappings;
using TichuSensei.Core.Domain.Entities;
using TichuSensei.Core.Domain.Enums;

namespace TichuSensei.Core.Application.Calls.Models.DTOs
{
    /// <summary>
    /// A Call Data Transfer Object. It does not include the Round object.
    /// </summary>
    public class CallDTO : IMapFrom<Call>
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public long CallId { get; set; }
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public long PlayerId { get; set; }
        /// <summary>
        /// The team's unique Id.
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// The call the player made for this hand. Can be None, Tichu or Grand Tichu.
        /// </summary>
        public TichuCallType CallType { get; set; }
        /// <summary>
        /// If the Tichu or Grand Tichu call the player made succeeded. Null, if the player didn't make a call.
        /// </summary>
        public bool? Success { get; set; }
        /// <summary>
        /// The round's unique Id.
        /// </summary>
        public string RoundId { get; set; }
    }    
}

