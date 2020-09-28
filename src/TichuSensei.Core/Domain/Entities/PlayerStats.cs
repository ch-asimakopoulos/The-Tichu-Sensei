namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// The player stats of a Tichu player.
    /// </summary>
    public class PlayerStats
    {
        /// <summary>
        /// The unique id. 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The player's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The total number of games this player has played.
        /// </summary>
        public long GamesTotal { get; set; }
        /// <summary>
        /// The total number of games this player has won.
        /// </summary>
        public long GamesWon { get; set; }
        /// <summary>
        /// The total number of rounds this player has played.
        /// </summary>
        public long RoundsTotal { get; set; }
        /// <summary>
        /// The total number of rounds this player has played that ended in a draw.
        /// </summary>
        public long RoundsDrawn { get; set; }
        /// <summary>
        /// The total number of rounds this player has won.
        /// </summary>
        public long RoundsWon { get; set; }
        /// <summary>
        /// The total number of points this player has won.
        /// </summary>
        public long PointsWon { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this player has made.
        /// </summary>
        public long GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this player has won.
        /// </summary>
        public long GrandTichuCallsWon { get; set; }
        /// <summary>
        /// The total number of Tichu calls this player has made.
        /// </summary>
        public long TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this player has won.
        /// </summary>
        public long TichuCallsWon { get; set; }
        /// <summary>
        /// The total number of High Cards the player's teams had in their games.
        /// </summary>
        public long HighCardsTotal { get; set; }
        /// <summary>
        /// The total number of High Cards the player's opponents had in their games.
        /// </summary>
        public long OpponentsHighCardsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the player's teams had in their games.
        /// </summary>
        public long BombsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the player's opponents had in their games.
        /// </summary>
        public long OpponentsBombsTotal { get; set; }
        /// <summary>
        /// The player's unique Id.
        /// </summary>
        public long PlayerId { get; set; }
        /// <summary>
        /// The player's information. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Player Player { get; set; }
    }
}
