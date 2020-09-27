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
        public string Id { get; set; }
        /// <summary>
        /// The team's Elo rating. Elo is a ranking used to compare teams' and players' proficiency.
        /// </summary>
        public int EloRating { get; set; }
        /// <summary>
        /// The total number of games this team has played.
        /// </summary>
        public int GamesTotal { get; set; }
        /// <summary>
        /// The total number of games this team has won.
        /// </summary>
        public int GamesWon { get; set; }
        /// <summary>
        /// The total number of rounds this team has played.
        /// </summary>
        public int RoundsTotal { get; set; }
        /// <summary>
        /// The total number of rounds this team has played that ended in a draw.
        /// </summary>
        public int RoundsDrawn { get; set; }
        /// <summary>
        /// The total number of rounds this team has won.
        /// </summary>
        public int RoundsWon { get; set; }
        /// <summary>
        /// The total number of points this team has won.
        /// </summary>
        public int PointsWon { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this team has made.
        /// </summary>
        public int GrandTichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Grand Tichu calls this team has won.
        /// </summary>
        public int GrandTichuCallsWon { get; set; }
        /// <summary>
        /// The total number of Tichu calls this team has made.
        /// </summary>
        public int TichuCallsTotal { get; set; }
        /// <summary>
        /// The total number of Tichu calls this team has won.
        /// </summary>
        public int TichuCallsWon { get; set; }
        /// <summary>
        /// The total number of High Cards the team had in their games.
        /// </summary>
        public int HighCardsTotal { get; set; }
        /// <summary>
        /// The total number of High Cards the team's opponents had in their games.
        /// </summary>
        public int OpponentsHighCardsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the team had in their games.
        /// </summary>
        public int BombsTotal { get; set; }
        /// <summary>
        /// The total number of Bombs the team's opponents had in their games.
        /// </summary>
        public int OpponentsBombsTotal { get; set; }
        /// <summary>
        /// The team's unique Id.
        /// </summary>
        public string TeamId { get; set; }
        /// <summary>
        /// The team's information. Will only be computed when needed, via lazy loading.
        /// </summary>
        public virtual Team Team { get; set; }
    }
}
