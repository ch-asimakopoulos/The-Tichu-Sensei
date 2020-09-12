using TichuSensei.Core.Domain.Enums;

namespace TichuSensei.Core.Domain.Entities
{
    public class Call
    {
        public string CallId { get; set; }
        public string PlayerId { get; set; }
        public string TeamId { get; set; }
        public TichuCallType CallType { get; set; }
        public bool Success { get; set; }
        public string RoundId { get; set; }
        public virtual Round Round { get; set; }
    }
}
