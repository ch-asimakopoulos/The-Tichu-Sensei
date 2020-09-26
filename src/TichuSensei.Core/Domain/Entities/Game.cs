using System;
using System.Collections.Generic;
using TichuSensei.Core.Domain.Events;
using TichuSensei.Kernel.BaseModels;

namespace TichuSensei.Core.Domain.Entities
{
    public class Game
    {
        public string GameId { get; set; }
        public bool MercyRule { get; set; }
        public bool GameOver { get; set; }
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
        public virtual PlayerStats Stats { get; set; }

    }
}
