namespace TichuSensei.Kernel.Consts
{
    /// <summary>
    /// Elo ranking related constants.
    /// </summary>
    public static class Elo
    {
        /// <summary>
        /// The base elo ranking that each player starts with.
        /// </summary>
        public const int Base = 1500;
        /// <summary>
        /// The maximum increase or decrease of elo rating that can occur in a Tichu game.
        /// </summary>
        public const int MaxChange = 19;
        /// <summary>
        /// The minimum increase or decrease of elo rating that can occur in a Tichu game.
        /// </summary>
        public const int MinChange = 2;
        /// <summary>
        /// The K factor, used to calculate the Elo changes depending on the current ratings of all four players and the game result.
        /// </summary>
        public const int kFactor = 20;
        /// <summary>
        /// The minimum games a player must have played in order to appear in the Elo rankings list.
        /// </summary>
        public const int MinGamesForEligibility = 20;

    }
}
