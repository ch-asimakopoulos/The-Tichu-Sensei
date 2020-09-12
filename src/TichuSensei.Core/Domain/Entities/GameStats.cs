using System.Collections.Generic;


namespace TichuSensei.Core.Domain.Entities
{
    public class GameStats
    {
        public string Id { get; set; }
        public int RoundsTotal { get; set; }
        public int RoundsWonTeamOne { get; set; }
        public int RoundsWonTeamTwo { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public int GrandTichuCallsTotalTeamOne { get; set; }
        public int GrandTichuCallsWonTeamOne { get; set; }
        public int GrandTichuCallsTotalTeamTwo { get; set; }
        public int GrandTichuCallsWonTeamTwo { get; set; }
        public int TichuCallsTotalTeamOne { get; set; }
        public int TichuCallsWonTeamOne { get; set; }
        public int TichuCallsTotalTeamTwo { get; set; }
        public int TichuCallsWonTeamTwo { get; set; }
        public int HighCardsTotalTeamOne { get; set; }
        public int HighCardsTotalTeamTwo { get; set; }
        public int BombsTotalTeamOne { get; set; }
        public int BombsTotalTeamTwo { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

    }
}
