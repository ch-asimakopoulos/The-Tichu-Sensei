using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Domain.Policies
{
    /// <summary>
    /// Policies regarding the Elo ranking.
    /// </summary>
    public static class EloPolicies
    {
        /// <summary>
        /// Elo Policies regarding players. 
        /// The Elo rating system is a method for calculating the relative skill levels of players in zero-sum games such as chess. 
        /// </summary>
        public static class PlayerPolicies
        {
            /// <summary>
            /// Determines if a player is eligible for Elo Rankings. To be eligible a player must have played more than a certain number of matches.
            /// </summary>
            /// <param name="player">The player whose eligibility will be checked.</param>
            /// <returns>A boolean value determining if the player is eligible or not.</returns>
            public static bool IsEloRankingEligible(Player player) => player.Stats.GamesTotal >= Kernel.Consts.Elo.MinGamesForEligibility;

            /// <summary>
            /// Conforms an Elo change for a player to the minimum and maximum changes allowed.
            /// </summary>
            /// <param name="EloChange">The points the player won or lost.</param>
            /// <returns>The points that the player will win or lose after conforming to the max and min Elo change bounds.</returns>
            public static int ConformEloChangeToBounds(int EloChange)
            {
                if (EloChange > Kernel.Consts.Elo.MaxChange) return Kernel.Consts.Elo.MaxChange;
                if (EloChange < Kernel.Consts.Elo.MinChange) return Kernel.Consts.Elo.MinChange;
                return EloChange;
            }

        }


        /// <summary>
        /// Elo Policies regarding teams.
        /// </summary>
        public static class TeamPolicies
        {
            /// <summary>
            /// Determines if a team is eligible for Elo Rankings. To be eligible a team must have played more than a certain number of matches.
            /// </summary>
            /// <param name="team">The team whose eligibility will be checked.</param>
            /// <returns>A boolean value determining if the team is eligible or not.</returns>
            public static bool IsEloRankingEligible(Team team) => team.Stats.GamesTotal >= Kernel.Consts.Elo.MinGamesForEligibility;

            /// <summary>
            /// Conforms an Elo change for a team to the minimum and maximum changes allowed.
            /// </summary>
            /// <param name="EloChange">The points the team won or lost.</param>
            /// <returns>The points that the team will win or lose after conforming to the max and min Elo change bounds.</returns>
            public static int ConformEloChangeToBounds(int EloChange)
            {
                if (EloChange > Kernel.Consts.Elo.MaxChange) return Kernel.Consts.Elo.MaxChange;
                if (EloChange < Kernel.Consts.Elo.MinChange) return Kernel.Consts.Elo.MinChange;
                return EloChange;
            }
        }


    }
}
