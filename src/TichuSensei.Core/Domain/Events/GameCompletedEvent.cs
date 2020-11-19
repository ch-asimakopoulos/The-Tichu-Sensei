using System;
using System.Runtime.CompilerServices;
using TichuSensei.Core.Domain.Entities;
using TichuSensei.Core.Domain.Enums.Game;
using TichuSensei.Core.Domain.Exceptions;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Events
{
    public class GameCompletedEvent : DomainEvent
    {
        public GameCompletedEvent(Game game)
        {
            if (!_ValidateGameCompletion())
                throw new GameInvalidCompletionException(game, new Exception("Game was marked complete, despite not having a team winning it."));

            Game = game;
            _WinningTeam = Game.Stats.ScoreTeamOne > Game.Stats.ScoreTeamTwo ? WinningTeam.One : WinningTeam.Two;

            (int Team1EloChange, int Team2EloChange) = _CalculateEloChanges();

        }
        private Game Game { get; }
        private WinningTeam _WinningTeam { get;  }

        private bool _ValidateGameCompletion()
        {
            if (Game.MercyRule && Math.Abs(Game.Stats.ScoreTeamOne - Game.Stats.ScoreTeamTwo) >= Kernel.Consts.Game.MercyRuleDifference)
                return true;
            if ((Game.Stats.ScoreTeamOne > Kernel.Consts.Game.GameEndScore || Game.Stats.ScoreTeamTwo > Kernel.Consts.Game.GameEndScore)
                && (Game.Stats.ScoreTeamTwo != Game.Stats.ScoreTeamOne))
                return true;
            return false;
        }
        private (int Team1EloChange, int Team2EloChange) _CalculateEloChanges() => (0, 0);
    }
}
