using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TichuSensei.Core.Domain.Entities
{
    public class Round
    {
        public string RoundId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEnded { get; set; }
        public string TeamOneId { get; set; }
        public virtual Team TeamOne { get; set; }
        public string TeamTwoId { get; set; }
        public virtual Team TeamTwo { get; set; }
        public string PlayerOneId { get; set; }
        public Player PlayerOne { get; set; }
        public string PlayerTwoId { get; set; }
        public Player PlayerTwo { get; set; }
        public string PlayerThreeId { get; set; }
        public Player PlayerThree { get; set; }
        public string PlayerFourId { get; set; }
        public Player PlayerFour { get; set; }
        public ICollection<Call> Calls { get; set; }
        public int ScoreTeamOne { get; set; }
        public int ScoreTeamTwo { get; set; }
        public int HighCardsTeamOne { get; set; }
        public int HighCardsTeamTwo { get; set; }
        public int BombsTeamOne { get; set; }
        public int BombsTeamTwo { get; set; }

    }
}
