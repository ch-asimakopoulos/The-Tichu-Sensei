

namespace TichuSensei.Core.Domain.Entities
{
    public class PlayerStats
    {
        public string Id { get; set; }
        public int EloRating { get; set; }
        public int GamesTotal { get; set; }
        public int GamesWon { get; set; }
        public int RoundsTotal { get; set; }
        public int RoundsDrawn { get; set; }
        public int RoundsWon { get; set; }
        public int PointsWon { get; set; }
        public int GrandTichuCallsTotal { get; set; }
        public int GrandTichuCallsWon { get; set; }
        public int TichuCallsTotal { get; set; }
        public int TichuCallsWon { get; set; }
        public int HighCardsTotal { get; set; }
        public int OpponentsHighCardsTotal { get; set; }
        public int BombsTotal { get; set; }
        public int OpponentsBombsTotal { get; set; }
        public string PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
