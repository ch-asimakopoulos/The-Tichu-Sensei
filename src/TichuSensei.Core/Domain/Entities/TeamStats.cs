namespace TichuSensei.Core.Domain.Entities
{
    /// <summary>
    /// The team stats of a Tichu team of two players.
    /// </summary>
    public class TeamStats
    {
        /// <summary>
        /// The unique id. 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The team's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The total number of games this team has played.
        /// </summary>
        public long GamesTotal { get; set; }
        /// <summary>
        /// The total number of games this team has won.
        /// </summary>
        public long GamesWon { get; set; }
        /// <summary>
        /// The total number of rounds this team has played.
        /// </summary>
        public long RoundsTotal { get; set; }
        /// <summary>
        /// The total number of rounds this team has played that ended in a draw.
        /// </summary>
        public long RoundsDrawn { get; set; }
        /// <summary>
        /// The total number of rounds this team has won.
        /// </summary>
        public long RoundsWon { get; set; }
        /// <summary>
        /// The total number of points this team has won.
        /// </summary>
        public long PointsWon { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this team has made.
        /// </summary>
        public long GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this team has won.
        /// </summary>
        public long GrandTichuCallsWon { get; set; }
        /// <summary>
        /// The total number of Tichu calls this team has made.
        /// </summary>
        public long TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this team has won.
        /// </summary>
        public long TichuCallsWon { get; set; }
        /// <summary>
        /// The total number of High Cards the team had in their games.
        /// </summary>
        public long HighCardsTotal { get; set; }
        /// <summary>
        /// The total number of High Cards the team's opponents had in their games.
        /// </summary>
        public long OpponentsHighCardsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the team had in their games.
        /// </summary>
        public long BombsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the team's opponents had in their games.
        /// </summary>
        public long OpponentsBombsTotal { get; set; }
        /// <summary>
        /// The team's unique Id.
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// The team's information. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team Team { get; set; }
    }
}
