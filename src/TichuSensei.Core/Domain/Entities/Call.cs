using TichuSensei.Core.Domain.Enums;

namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// A class describing whether a player called Tichu or Grand Tichu on a particular hand.
    /// </summary>
    public class Call
    {
        /// <summary>
        /// The unique Id.
        /// </summary>
        public string CallId { get; set; }
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public string PlayerId { get; set; }
        /// <summary>
        /// The team's unique Id.
        /// </summary>
        public string TeamId { get; set; }
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
        /// <summary>
        /// The round's object. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Round Round { get; set; }
    }
}
