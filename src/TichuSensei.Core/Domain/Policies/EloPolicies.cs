using TichuSensei.Core.Domain.Entities;
using TichuSensei.Core.Domain.Enums.Game;

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
            /// Calculates the Elo changes per team using the Elo formula: <seealso cref="https://en.wikipedia.org/wiki/Elo_rating_system#Mathematical_details"/>, <seealso cref="https://en.wikipedia.org/wiki/Go_ranks_and_ratings#Elo_ratings_as_used_in_Go"/>
            /// </summary>
            /// <param name="team1">First team of the game.</param>
            /// <param name="team2">Second team of the game.</param>
            /// <param name="winningTeam">Enum that denotes the winning team.</param>
            /// <returns>The change that will happen for each team's Elo rankings (upwards or downwards depending on if the team won or lost).</returns>
            public static int CalculateEloChange(Team team1, Team team2, WinningTeam winningTeam)
            {
                return 0;
            }

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
