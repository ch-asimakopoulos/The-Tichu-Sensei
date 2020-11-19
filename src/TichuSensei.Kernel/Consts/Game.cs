namespace TichuSensei.Kernel.Consts
{
    /// <summary>
    /// Game related constants.
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// The score which one team needs to reach in order to win the game.
        /// </summary>
        public static int GameEndScore = 1000;
        /// <summary>
        /// The difference in the scores of the two teams which will automatically trigger a game completion if mercy rule is enabled.
        /// </summary>
        public static int MercyRuleDifference = 1000;
    }
}
