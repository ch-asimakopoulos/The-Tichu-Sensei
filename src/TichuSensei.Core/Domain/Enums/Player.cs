using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TichuSensei.Core.Domain.Enums.Player
{
    public enum OrderBy
    {
        Name,
        DateCreated
    }
    public enum OrderByStats
    {
        Name,
        DateCreated,
        GamesWonPercentage,
        RoundsWonPercentage,
        PointsPerRound,
        GrandTichuCallsWonPercentage,
        TichuCallsWonPercentage,
        HighCardsPerRound,
        OpponentsHighCardsPerRound,
        BombsPerRound,
        OpponentsBombsPerRound
    }
}
