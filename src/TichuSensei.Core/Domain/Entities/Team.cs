using System;


namespace TichuSensei.Core.Domain.Entities
{
    public class Team
    {
        public string TeamId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string PlayerOneId { get; set; }
        public Player PlayerOne { get; set; }
        public string PlayerTwoId { get; set; }
        public Player PlayerTwo { get; set; }
        public virtual TeamStats Stats { get; set; }
    }
}
